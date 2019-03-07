using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CoreGiris.Models;

namespace CoreGiris.Controllers
{
    public class HomeController : Controller
    {
        List<Kisi> kisiler = new List<Kisi>()
        {
            new Kisi()
            {
                Ad = "Kamil",
                Soyad = "Falan"
            },
            new Kisi()
            {
                Ad = "Hakkı",
                Soyad = "Filan"
            }
        };
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";
            ViewBag.Hello = "Hello World";
            return View(kisiler);
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
