using System;
using System.IO;
using System.Linq;
using CMS.Data;
using CMS.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CMS.Controllers
{
    public class MembersController : Controller
    {
        private readonly DataContext _context;
        private readonly IWebHostEnvironment _environment;

        public MembersController(DataContext context, IWebHostEnvironment environment)
        {
            _context = context;
            _environment = environment;
        }

        public IActionResult Index()
        {
            var members = _context.members.ToList();
            return View(members);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Member member, IFormFile image)
        {
            if (ModelState.IsValid)
            {
                string wwwRootPath = _environment.WebRootPath;
                if (image != null)
                {
                    string fileName = Guid.NewGuid().ToString();
                    var uploads = Path.Combine(wwwRootPath, @"images\products");
                    var extension = Path.GetExtension(image.FileName);

                    using (var fileStreams = new FileStream(Path.Combine(uploads, fileName + extension), FileMode.Create))
                    {
                        image.CopyTo(fileStreams);
                    }
                    member.ImageUrl = @"\images\products\" + fileName + extension;
                }

                _context.members.Add(member);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(member);
        }

        public IActionResult Edit(int id)
        {
            var member = _context.members.Find(id);

            if (member == null)
            {
                return NotFound();
            }

            return View(member);
        }

        [HttpPost]
        public IActionResult Edit(Member member, IFormFile image)
        {
            if (ModelState.IsValid)
            {
                string wwwRootPath = _environment.WebRootPath;

                if (image != null)
                {
                    string fileName = Guid.NewGuid().ToString();
                    var uploads = Path.Combine(wwwRootPath, @"images\products");
                    var extension = Path.GetExtension(image.FileName);

                    // Delete the old image file if it exists
                    if (!string.IsNullOrEmpty(member.ImageUrl))
                    {
                        var oldFilePath = Path.Combine(uploads, member.ImageUrl.TrimStart('\\'));
                        if (System.IO.File.Exists(oldFilePath))
                        {
                            System.IO.File.Delete(oldFilePath);
                        }
                    }

                    using (var fileStreams = new FileStream(Path.Combine(uploads, fileName + extension), FileMode.Create))
                    {
                        image.CopyTo(fileStreams);
                    }
                    member.ImageUrl = @"\images\products\" + fileName + extension;
                }

                _context.members.Update(member);
                _context.SaveChanges();

                return RedirectToAction("Index");
            }

            return View(member);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id)
        {
            var member = _context.members.Find(id);

            if (member == null)
            {
                return NotFound();
            }

            // Delete the image file if it exists
            if (!string.IsNullOrEmpty(member.ImageUrl))
            {
                var filePath = Path.Combine(_environment.WebRootPath, member.ImageUrl.TrimStart('\\'));
                if (System.IO.File.Exists(filePath))
                {
                    System.IO.File.Delete(filePath);
                }
            }

            _context.members.Remove(member);
            _context.SaveChanges();

            return RedirectToAction(nameof(Index));
        }
    }
}
