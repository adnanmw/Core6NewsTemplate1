using CMS.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using CMS.Data;
using CMS.Models.Viewmodel;

namespace CMS.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly DataContext _context;

        public HomeController(ILogger<HomeController> logger, DataContext context)
        {
            _logger = logger;
            _context = context; 
        }



        public async Task<IActionResult> Index()
        {
            var homeViewModel = new HomeViewModel
            {
                Logos = await _context.Logos.ToListAsync(),
                SliderImages = await _context.SliderImages.ToListAsync(),
                AboutUs = await _context.AboutUs.FirstOrDefaultAsync(),
                Bloggers=  await _context.Blogs.Include(b => b.Category).ToListAsync(),
                Services= await _context.Services.ToListAsync(),
                members= await  _context.members.ToListAsync(),
                OrganizationStatistics =await _context.Statistics.FirstOrDefaultAsync(),
                categories = await _context.Categories.ToListAsync(),
                Footer = await _context.Footer.FirstOrDefaultAsync(),
                SocialMediaLinks= await _context.SocialMediaLinks.ToListAsync(),
            };
            return View(homeViewModel);
        }



        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}