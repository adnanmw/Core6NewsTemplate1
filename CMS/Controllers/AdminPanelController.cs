using Microsoft.AspNetCore.Mvc;

namespace CMS.Controllers
{
    public class AdminPanelController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
