// Controllers/SliderImagesController.cs
using CMS.Data;
using CMS.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.IO;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Threading.Tasks;

namespace CMS.Controllers
{
    public class SliderImagesController : Controller
    {
        private readonly DataContext _context;

        public SliderImagesController(DataContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var sliderImages = await _context.SliderImages.ToListAsync();
            return View(sliderImages);
        }
            public IActionResult Upload()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Upload(IFormFile file, string Header, string Paragraph)
        {
            if (file != null && file.Length > 0)
            {
                var sliderImage = new SliderImage
                {
                    FileName = Path.GetFileName(file.FileName),
                    ContentType = file.ContentType,
                    Data = new byte[file.Length],
                    Header = Header,
                    Paragraph= Paragraph
                };

                using (var stream = new MemoryStream())
                {
                    await file.CopyToAsync(stream);
                    sliderImage.Data = stream.ToArray();
                }

                _context.SliderImages.Add(sliderImage);
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

            var sliderImage = await _context.SliderImages.FindAsync(id);

            if (sliderImage == null)
            {
                return NotFound();
            }

            return File(sliderImage.Data, sliderImage.ContentType);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            var sliderImage = await _context.SliderImages.FindAsync(id);

            if (sliderImage == null)
            {
                return NotFound();
            }

            _context.SliderImages.Remove(sliderImage);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }
    }
}
