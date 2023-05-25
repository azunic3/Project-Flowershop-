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
            List<Product> bestSellers = _context.Products.ToList();
            for (int i = 0; i < bestSellers.Count; i++)
            {
                for (int j = i + 1; j < bestSellers.Count; j++)
                {
                    if (bestSellers[i].SalesHistory < bestSellers[j].SalesHistory)
                    {
                        Product product = bestSellers[i];
                        bestSellers[i] = bestSellers[j];
                        bestSellers[j] = product;
                    }
                }
            }
            for (int i = 0; i < 4; i++)
                ViewBag.bestSellers = bestSellers[i];
        }
    }
}
