using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Perque.Admin.Areas.Productivity.Models;

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