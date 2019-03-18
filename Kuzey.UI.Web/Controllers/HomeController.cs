using Kuzey.BLL.Repository.Abstracts;
using Kuzey.Models.Entities;
using Kuzey.Models.IdentityEntities;
using Kuzey.UI.Web.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Linq;
using Kuzey.BLL.Account;
using Kuzey.BLL.Repository;
using Microsoft.EntityFrameworkCore;

namespace Kuzey.UI.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly IRepository<Category, int> _categoryRepo;
        private readonly IRepository<Product, string> _productRepo;
        private readonly MembershipTools _membershipTools;

        public HomeController(IRepository<Category, int> categoryRepo, IRepository<Product, string> productRepo, MembershipTools membershipTools)
        {
            _categoryRepo = categoryRepo;
            _productRepo = productRepo;
            _membershipTools = membershipTools;
        }

        public IActionResult Index()
        {
            if (!_categoryRepo.GetAll().Any())
            {
                _categoryRepo.Insert(new Category()
                {
                    CategoryName = "Beverages"
                });
                _categoryRepo.Insert(new Category()
                {
                    CategoryName = "Condiments"
                });
            }

            if (!_productRepo.GetAll().Any())
            {
                var catId = _categoryRepo.GetAll().FirstOrDefault().Id;
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

            var data = _productRepo.GetAll().Include(x => x.Category).ToList();
            foreach (var product in data)
            {
                product.UnitPrice *= 1.05m;
                _productRepo.Update(product);
            }
            return View(data);
        }

        public IActionResult About()
        {
            var userManager = _membershipTools.UserManager;
            var signInManager = _membershipTools.SignInManager;
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
