using Kuzey.BLL.Repository.Abstracts;
using Kuzey.Models.Entities;
using Kuzey.Models.IdentityEntities;
using Kuzey.UI.Web.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Linq;
using Kuzey.BLL.Repository;

namespace Kuzey.UI.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly IRepository<Category, int> _categRepo;
        private readonly IRepository<Product, string> _productRepo;

        public HomeController(IRepository<Category, int> categRepo, IRepository<Product, string> productRepo)
        {
            _categRepo = categRepo;
            _productRepo = productRepo;
        }

        public IActionResult Index()
        {
            if (!_categRepo.Queryable().Any())
            {
                _categRepo.Insert(new Category()
                {
                    CategoryName = "Beverages"
                });
                _categRepo.Insert(new Category()
                {
                    CategoryName = "Condiments"
                });
            }

            if (!_productRepo.Queryable().Any())
            {
                var catId = _categRepo.Queryable().FirstOrDefault().Id;
                _productRepo.Insert(new Product()
                {
                    CategoryId = catId,
                    ProductName = "Chai",
                    UnitPrice = 18.5m
                });
                _productRepo.Insert(new Product()
                {
                    CategoryId = catId,
                    ProductName = "Chang",
                    UnitPrice = 20
                });
            }

            var data = ((ProductRepo)_productRepo).GetAll("Category");

            return View(data);
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
