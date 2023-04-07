using CMS.Data;
using CMS.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace CMS.Controllers
{
    public class SocialMediaLinksController : Controller
    {
        private readonly DataContext _context;

        public SocialMediaLinksController(DataContext context)
        {
            _context = context;
        }

        // GET: SocialMediaLinks
        public async Task<IActionResult> Index()
        {
            var socialMediaLinks = await _context.SocialMediaLinks.ToListAsync();
            return View(socialMediaLinks);
        }

        // GET: SocialMediaLinks/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: SocialMediaLinks/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,FacebookLink,TwitterLink,GoogleLink,InstagramLink")] SocialMediaLinks socialMediaLinks)
        {
            if (ModelState.IsValid)
            {
                _context.Add(socialMediaLinks);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(socialMediaLinks);
        }

        // GET: SocialMediaLinks/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var socialMediaLinks = await _context.SocialMediaLinks.FindAsync(id);
            if (socialMediaLinks == null)
            {
                return NotFound();
            }
            return View(socialMediaLinks);
        }

        // POST: SocialMediaLinks/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,FacebookLink,TwitterLink,GoogleLink,InstagramLink")] SocialMediaLinks socialMediaLinks)
        {
            if (id != socialMediaLinks.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                
                return RedirectToAction(nameof(Index));
            }
            return View(socialMediaLinks);
        }

        // GET: SocialMediaLinks/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var socialMediaLinks = await _context.SocialMediaLinks
                .FirstOrDefaultAsync(m => m.Id == id);
            if (socialMediaLinks == null)
            {
                return NotFound();
            }

            return View(socialMediaLinks);
        }

        // POST: SocialMediaLinks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var socialMediaLinks = await _context.SocialMediaLinks.FindAsync(id);
            _context.SocialMediaLinks.Remove(socialMediaLinks);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }


    }
}
