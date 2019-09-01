using Microsoft.AspNetCore.Mvc;

namespace Perque.Admin.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}