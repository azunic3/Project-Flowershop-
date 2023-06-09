using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Ayana.Data;
using Ayana.Models;
using System.Security.Claims;
using Ayana.Migrations;
using Humanizer;
using Microsoft.VisualStudio.Web.CodeGeneration.Contracts.Messaging;
using static Humanizer.In;
using static Humanizer.On;
using System.Diagnostics;
using System.Reflection.Metadata;
using System.Reflection.PortableExecutable;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace Ayana.Controllers
{
    public class DtoRequestsController : Controller
    {
        private readonly ApplicationDbContext _context;
       
        public DtoRequestsController(ApplicationDbContext context)
        {
            _context = context;
        }

        
        public async Task<IActionResult> AddToCart(int id)
        {
            string userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            if (userId == null)
                return View("Error");


            var cart = _context.Cart.FirstOrDefault(o => o.CustomerID == userId && o.ProductID == id);



            if (cart == null)

            {
                Cart cart1 = new Cart()
                {
                    CustomerID = userId,
                    ProductID = id,
                    ProductQuantity = 1
                    
                };

                _context.Add(cart1);
                await _context.SaveChangesAsync();
            }
            else
            {
                cart.ProductQuantity ++;
                await _context.SaveChangesAsync();

            }
          
            return Json(new { message = "Radi!" });

        }

     
        public List<List<Product>> GetCartProducts(List<Cart> carts)
        {
            List<List<Product>> cartProducts = new List<List<Product>>();

            foreach (var cart in carts)
            {
                var products = _context.Cart
                    .Where(po => po.CartID == cart.CartID)
                    .Select(po => po.Product)
                    .ToList();

                cartProducts.Add(products);
            }

            return cartProducts;
        }

        // GET: DtoRequests/Create
        public IActionResult Cart()
        {
            string userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            // Retrieve user-specific orders based on the CustomerId
            List<Cart> userCarts = _context.Cart
                .Where(o => o.CustomerID == userId)
                .ToList();

            // Get the associated products for each order
            List<List<Product>> cartProducts = GetCartProducts(userCarts);

            // Pass the userOrders and orderProducts to the view
            ViewBag.UserCarts = userCarts;
            ViewBag.CartProducts = cartProducts;

            // Render the view
   
            return View();
        }


        // GET: Subscriptions/Details/5
        public Task<IActionResult> SubscriptionOrder(string data1, double data2)
        {
            ViewBag.Data1 = data1;
            ViewBag.Data2 = Math.Round(data2, 2);

            return Task.FromResult<IActionResult>(View());
        }

        // POST: DtoRequests/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> SubscriptionCreate([Bind("Name,Price,personalMessage,DeliveryDate")] Subscription subscription, [Bind("DeliveryAddress,BankAccount,PaymentType")] Payment payment)
        {
            //TODO needs fixing --> customer id change to string in all other tables

            string userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            var existingCustomer = _context.Users.FirstOrDefault(m => m.Id == userId);
            if (userId == null)
            {
                return View("~/Views/Shared/Error.cshtml");
            }
          

            // Set up the payment instance
            Payment payment1 = new Payment
            {
                BankAccount=payment.BankAccount,
                PayedAmount =subscription.Price, 
                DeliveryAddress = payment.DeliveryAddress,
                DiscountID = null,
                PaymentType = payment.PaymentType

            };

            // Save the payment instance to the database
            _context.Add(payment1);
            await _context.SaveChangesAsync();

            var subsType = SubscriptionType.Month;

            if (subscription.Name == "Three month Package")
                subsType = SubscriptionType.ThreeMonth;
            else if (subscription.Name == "Six month Package")
                subsType = SubscriptionType.SixMonth;


            // Set up the payment instance
            Subscription subscription1 = new Subscription
            {
                Name = subscription.Name,
                DeliveryDate= subscription.DeliveryDate,
                SubscriptionType =subsType,
                CustomerID=userId,
                PaymentID=payment1.PaymentID,
                Price = subscription.Price,
                personalMessage = subscription.personalMessage

            };


            // Save the subscription to the database
            _context.Add(subscription1);
            await _context.SaveChangesAsync();



            return Redirect("/Home");
        }
    }
}
