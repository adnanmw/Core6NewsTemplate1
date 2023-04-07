
using CMS.Data;
using CMS.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using System.Diagnostics;

namespace CMS.Controllers
{
    public class BlogController : Controller
    {
        private readonly DataContext _db;
        private readonly IWebHostEnvironment _env;


        public BlogController(DataContext db, IWebHostEnvironment env)
        {
            _db = db;
            _env = env;
        }

        public IActionResult Index()
        {
            var blogs = _db.Blogs.Include(b => b.Category).ToList();

            return View(blogs);
        }

        public IActionResult Create()
        {
            ViewBag.Categories = _db.Categories.ToList();
            return View();
        }

        [HttpPost]
        public IActionResult Create(Blogger blog, IFormFile file)
        {
            if (ModelState.IsValid)
            {
                string wwwRootPath = _env.WebRootPath;
                if (file != null)
                {
                    string fileName = Guid.NewGuid().ToString();//unique filename
                    var uploads = Path.Combine(wwwRootPath, @"images\products");//used to combine the wwwRootPath and uploads strings to create the full path where the file will be saved.
                    var extension = Path.GetExtension(file.FileName);// get file extension type 

                    using (var fileStreams = new FileStream(Path.Combine(uploads, fileName + extension), FileMode.Create))
                    {
                        file.CopyTo(fileStreams);
                    }
                    blog.ImageUrl = @"\images\products\" + fileName + extension;

                }

                _db.Blogs.Add(blog);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Categories = _db.Categories.ToList();
            return View(blog);
        }

        public IActionResult Edit(int Id)
        {
            var blog = _db.Blogs.Find(Id);
            if (blog == null)
            {
                return NotFound();
            }

            ViewBag.Categories = _db.Categories.ToList();

            return View(blog);
        }

        [HttpPost]
        public IActionResult Edit(Blogger blog, IFormFile file)
        {
            if (ModelState.IsValid)
            {
                string wwwRootPath = _env.WebRootPath;

                if (file != null)
                {
                    string fileName = Guid.NewGuid().ToString();
                    var uploads = Path.Combine(wwwRootPath, @"images\products");
                    var extension = Path.GetExtension(file.FileName);

                    // Delete the old image file if it exists
                    if (!string.IsNullOrEmpty(blog.ImageUrl))
                    {
                        var oldFilePath = Path.Combine(uploads, blog.ImageUrl.TrimStart('\\'));
                        if (System.IO.File.Exists(oldFilePath))
                        {
                            System.IO.File.Delete(oldFilePath);
                        }
                    }

                    using (var fileStreams = new FileStream(Path.Combine(uploads, fileName + extension), FileMode.Create))
                    {
                        file.CopyTo(fileStreams);
                    }
                    blog.ImageUrl = @"\images\products\" + fileName + extension;
                }

                _db.Blogs.Update(blog);
                _db.SaveChanges();

                return RedirectToAction("Index");
            }

            ViewBag.Categories = _db.Categories.ToList();

            return View(blog);
        }



        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int Id)
        {
            var blog = _db.Blogs.Find(Id);

            if (blog == null)
            {
                return NotFound();
            }

            _db.Blogs.Remove(blog);
            _db.SaveChanges();

            return RedirectToAction(nameof(Index));
        }












    }
}