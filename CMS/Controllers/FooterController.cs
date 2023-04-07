using CMS.Data;
using CMS.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace CMS.Controllers
{
    public class FooterController : Controller
    {
        private readonly DataContext _context;

        public FooterController(DataContext context)
        {
            _context = context;
        }

        // GET: Footer
        public IActionResult Index()
        {
            var footerList = _context.Footer.ToList();
            return View(footerList);
        }

       

        // GET: Footer/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Footer/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Footer footer)
        {
            if (ModelState.IsValid)
            {
                _context.Add(footer);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }

            return View(footer);
        }

        // GET: Footer/Edit/5
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var footer = _context.Footer.FirstOrDefault(f => f.Id == id);
            if (footer == null)
            {
                return NotFound();
            }

            return View(footer);
        }

        // POST: Footer/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, Footer footer)
        {
            if (id != footer.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(footer);
                    _context.SaveChanges();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FooterExists(footer.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }

            return View(footer);
        }

        // GET: Footer/Delete/5
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var footer = _context.Footer.FirstOrDefault(f => f.Id == id);
            if (footer == null)
            {
                return NotFound();
            }

            return View(footer);
        }

        // POST: Footer/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var footer = _context.Footer.FirstOrDefault(f => f.Id == id);
            _context.Footer.Remove(footer);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        private bool FooterExists(int id)
        {
            return _context.Footer.Any(f => f.Id == id);
        }
    }
}
