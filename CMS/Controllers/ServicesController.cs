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
    public class ServicesController : Controller
    {
        private readonly DataContext _context;
        private readonly IWebHostEnvironment _environment;

        public ServicesController(DataContext context, IWebHostEnvironment environment)
        {
            _context = context;
            _environment = environment;

          

        }

        public IActionResult Index()
        {
            var services = _context.Services.ToList();
            return View(services);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost, ActionName("Create")]
        [ValidateAntiForgeryToken]

        public IActionResult Create(Service service, IFormFile image)
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
                    service.ImageUrl = @"\images\products\" + fileName + extension;
                }

                _context.Services.Add(service);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(service);
        }

        public IActionResult Edit(int id)
        {
            var service = _context.Services.Find(id);

            if (service == null)
            {
                return NotFound();
            }

            return View(service);
        }

        [HttpPost]
        public IActionResult Edit(Service service, IFormFile image)
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
                    if (!string.IsNullOrEmpty(service.ImageUrl))
                    {
                        var oldFilePath = Path.Combine(uploads, service.ImageUrl.TrimStart('\\'));
                        if (System.IO.File.Exists(oldFilePath))
                        {
                            System.IO.File.Delete(oldFilePath);
                        }
                    }

                    using (var fileStreams = new FileStream(Path.Combine(uploads, fileName + extension), FileMode.Create))
                    {
                        image.CopyTo(fileStreams);
                    }
                    service.ImageUrl = @"\images\products\" + fileName + extension;
                }

                _context.Services.Update(service);
                _context.SaveChanges();

                return RedirectToAction("Index");
            }

            return View(service);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id)
        {
            var service = _context.Services.Find(id);

            if (service == null)
            {
                return NotFound();
            }

            // Delete the image file if it exists
            if (!string.IsNullOrEmpty(service.ImageUrl))
            {
                var filePath = Path.Combine(_environment.WebRootPath, service.ImageUrl.TrimStart('\\'));
                if (System.IO.File.Exists(filePath))
                {
                    System.IO.File.Delete(filePath);
                }
            }

            _context.Services.Remove(service);
            _context.SaveChanges();

            return RedirectToAction(nameof(Index));
        }
    }
}
