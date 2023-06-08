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

        // GET: DtoRequests/Create
        public IActionResult Create()
        {
            return View();
        }

        // GET: Subscriptions/Details/5
        public Task<IActionResult> Details(string data1, double data2)
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
        public async Task<IActionResult> Create([Bind("Name,Price,personalMessage")] Subscription subscription, [Bind("DeliveryAddress,BankAccount")] Payment payment)
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
                PayedAmount =subscription.Price, //hardcoded
                DeliveryAddress = payment.DeliveryAddress,
                DiscountID = null, //hardcoded
                PaymentType = PaymentType.Cash //hardcoded

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
                DeliveryDate= DateTime.Now,
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
