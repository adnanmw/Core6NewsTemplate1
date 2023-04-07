using CMS.Data;
using CMS.Models;
using CMS.Models.Viewmodel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CMS.Controllers
{
    public class LogoController : Controller
    {
        private readonly DataContext _context;

        public LogoController(DataContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            var logos = _context.Logos.ToList();

            var model = new HomeViewModel
            {
                Logos = logos
            };

            return View(model);
        }

        public IActionResult Upload()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Upload(IFormFile file)
        {
            if (file != null && file.Length > 0)
            {
                var logo = new Logo
                {
                    FileName = Path.GetFileName(file.FileName),
                    ContentType = file.ContentType,
                    Data = new byte[file.Length]
                };

                using (var stream = new MemoryStream())
                {
                    await file.CopyToAsync(stream);
                    logo.Data = stream.ToArray();
                }

                _context.Logos.Add(logo);
                await _context.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }

            return View();
        }

        public async Task<IActionResult> Display(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var logo = await _context.Logos.FindAsync(id);

            if (logo == null)
            {
                return NotFound();
            }

            return File(logo.Data, logo.ContentType);
        }

        public async Task<IActionResult> DisplayFirst()
        {
            var firstLogo = await _context.Logos.OrderBy(l => l.Id).FirstOrDefaultAsync();

            if (firstLogo == null)
            {
                return NotFound();
            }

            return File(firstLogo.Data, firstLogo.ContentType);
        }


        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var logo = await _context.Logos.FindAsync(id);
            if (logo == null)
            {
                return NotFound();
            }

            return View(logo);
        }

        [HttpPost, ActionName("DeleteConfirmed")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int logoId)
        {
            var logo = await _context.Logos.FindAsync(logoId);
            _context.Logos.Remove(logo);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }





    }
}
