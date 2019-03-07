using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoreGiris.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CoreGiris.Controllers
{
    public class CategoryController : Controller
    {
        public IActionResult Index()
        {
            var db = new MyContext();

            var data = db.Categories.Include(x=>x.Products).OrderBy(x => x.CategoryName).ToList();
            return View(data);
        }
        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Add(Category model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            var db = new MyContext();
            db.Categories.Add(new Category()
            {
                CategoryName = model.CategoryName
            });
            db.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
    }
}