using Ayana.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Ayana.Data;
using Microsoft.EntityFrameworkCore;
using System.Drawing.Printing;

namespace Ayana.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDbContext _context;

        public HomeController(ILogger<HomeController> logger, ApplicationDbContext context)
        {
            _logger = logger;
            _context = context;

        }

        public IActionResult Index()
        {
            bestSellers();
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
        public IActionResult Help()
        {
            return View();
        }
        public IActionResult DeliveryPolicy()
        {
            return View();
        }
        public IActionResult SignIn()
        {
            return View();
        }
        public IActionResult AboutUs()
        {
            return View();
        }
        public void bestSellers()
        {
            List<Product> orderded = _context.Products.ToList();
           
            orderded.OrderByDescending(x => x.SalesHistory);
            List<Product> bestSellers = new List<Product>();
            for(int i=0;i<3;i++)
                bestSellers.Add(orderded[i]);
                ViewBag.bestSellers = bestSellers;
            Console.WriteLine(bestSellers);
        }
        public void birthdayBestSellers()
        {
            List<Product> birthdayList = _context.Products.ToList().FindAll(x => x.Category == "Birthday");
            birthdayList.OrderByDescending(x=>x.SalesHistory);
            List<Product> birthdayBestSeller = new List<Product>();
            for (int i = 0; i < 4; i++)
                birthdayBestSeller.Insert(i, birthdayList[i]);
            ViewBag.birthdayBestSellers = birthdayBestSeller;
        }

    }
}
