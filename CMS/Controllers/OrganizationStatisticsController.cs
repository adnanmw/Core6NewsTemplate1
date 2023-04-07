using CMS.Data;
using CMS.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace CMS.Controllers
{
    public class OrganizationStatisticsController : Controller
    {
        private readonly DataContext _context;

        public OrganizationStatisticsController(DataContext context)
        {
            _context = context;
        }

        // GET: OrganizationStatistics
        public async Task<IActionResult> Index()
        {
            return View(await _context.Statistics.ToListAsync());
        }

     

        // GET: OrganizationStatistics/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: OrganizationStatistics/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Statistics,Committees,TeamMembers,Beneficiaries,ScientificActivities")] OrganizationStatistics organizationStatistics)
        {
            if (ModelState.IsValid)
            {
                _context.Add(organizationStatistics);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(organizationStatistics);
        }

        // GET: OrganizationStatistics/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var organizationStatistics = await _context.Statistics.FindAsync(id);
            if (organizationStatistics == null)
            {
                return NotFound();
            }

            return View(organizationStatistics);
        }

        // POST: OrganizationStatistics/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Statistics,Committees,TeamMembers,Beneficiaries,ScientificActivities")] OrganizationStatistics organizationStatistics)
        {
            if (id != organizationStatistics.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(organizationStatistics);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                catch
                {
                    return View(organizationStatistics);
                }
            }

            return View(organizationStatistics);
        }




        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var organizationStatistics = await _context.Statistics.FindAsync(id);
            if (organizationStatistics == null)
            {
                return NotFound();
            }

            _context.Statistics.Remove(organizationStatistics);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }






    }
}
