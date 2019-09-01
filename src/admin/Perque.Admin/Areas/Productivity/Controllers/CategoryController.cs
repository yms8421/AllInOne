using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Perque.Admin.Areas.Productivity.Controllers
{
    [Area("Productivity")]
    public class CategoryController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult New()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            return View();
        }

        [HttpGet]
        public IActionResult Detail(int id)
        {
            return View();
        }

        #region Bkz. Index(Form Collection).cshtml
        //[HttpPost]
        //public IActionResult Save(IFormCollection fc)
        //{
        //    var a = fc["Name"];
        //    var b = fc["Description"];
        //    return View();
        //} 
        #endregion

        #region Bkz. Index(Model Binding).cshtml
        //[HttpPost]
        //public IActionResult Save(CategoryViewModel model)
        //{
        //    return View();
        //} 
        #endregion
    }
}