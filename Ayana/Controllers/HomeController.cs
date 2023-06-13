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
using Ayana.Paterni;

namespace Ayana.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDbContext _context;
        public  UserState _userState;
        public HomeController(ILogger<HomeController> logger, ApplicationDbContext context)
        {
            _logger = logger;
            _context = context;

        }

        public IActionResult CategoryView(string category1)
        {
            List<Product>categoryList=_context.Products.ToList().FindAll(x => x.Category.ToLower() == category1.ToLower());
            if (categoryList.Count == 0)
            {
                categoryList= _context.Products.ToList().FindAll(x => x.FlowerType.ToLower() == category1.ToLower());

            }
            ViewBag.String = category1;
            ViewBag.category = categoryList;
            return View("~/Views/Products/SearchResult.cshtml", ViewBag.category);
        }

        public IActionResult Index()
        {
            _userState = new UserState();
            bestSellers();
            birthdayBestSellers();
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
            overallRating();
            return View();
        }
        public IActionResult Subscription()
        {
            return View();
        }

        public void overallRating(){ 
       
            List<Order> orders = _context.Orders.ToList();

            double? rating = 0;
            int temp = 0;

            for (int i = 0; i < orders.Count; i++)
            {
                if (orders[i].Rating != null)
                {
                    temp++;
                    rating += orders[i].Rating;
                }
            }
            if (temp != 0)
                ViewBag.rating = Math.Round((decimal)rating / temp, 1);
            else ViewBag.rating = 0;
               
            Console.WriteLine(rating);
        }
        public void bestSellers()
        {
            List<Product> orderded = _context.Products.ToList();
           
           orderded= orderded.OrderByDescending(x => x.Price).ToList(); //TODO
            List<Product> bestSellers = new List<Product>();
            for(int i = 0; i < 3; i++)
                bestSellers.Add(orderded[i]);
                ViewBag.bestSellers = bestSellers;
            Console.WriteLine(bestSellers);
        }
        public void birthdayBestSellers()
        {
            List<Product> birthdayList = _context.Products.ToList().FindAll(x => x.Category == "Birthday");
           birthdayList= birthdayList.OrderByDescending(x=>x.Price).ToList();//TODO
            List<Product> birthdayBestSeller = new List<Product>();
            for (int i = 0; i < 3; i++)
              birthdayBestSeller.Insert(i, birthdayList[i]);
            ViewBag.birthdayBestSellers = birthdayBestSeller;
        }

        public List<Product> Category(string category1)
        {
          return  _context.Products.ToList().FindAll(x => x.Category == category1);
        }

    }
}
