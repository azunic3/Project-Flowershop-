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
using Microsoft.EntityFrameworkCore.ValueGeneration.Internal;
using Microsoft.VisualBasic;
using Ayana.Paterni;

namespace Ayana.Controllers
{
    public class DtoRequestsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IDiscountCodeVerifier _discountCodeVerifier;

        public DtoRequestsController(ApplicationDbContext context, IDiscountCodeVerifier discountCodeVerifier)
        {
            _context = context;
            _discountCodeVerifier = discountCodeVerifier;
        }

        public async Task<IActionResult> ApplyDiscount(string code)
        {

            double discAmount = 0;
            string discType = "";
            var temp =  _discountCodeVerifier.VerifyDiscountCode(code); // Pozovite metodu za verifikaciju koda

            Discount discount;
            if (!temp)
                code = "Wrong code, try again...";
            else if (temp && !_discountCodeVerifier.VerifyExperationDate(code))
                code = "Code is expired...";
            else
            {
                discount = _discountCodeVerifier.GetDiscount(code);
                discAmount = discount.DiscountAmount;
                discType = discount.DiscountType.ToString();
            }

            var discountType1 = 0;

            if (discType == "AmountOff") discountType1 = 1;



            return RedirectToAction("Cart", new
            {
                discountAmount = discAmount.ToString(),
                discountType = discountType1.ToString(),
                discountCode = code
            });



        }

        public async Task<IActionResult> RemoveItem(int id)
        {

            string userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            if (userId == null)
                return View("Error");


            var cart = _context.Cart.FirstOrDefault(o => o.CustomerID == userId && o.ProductID == id);

            if (cart.ProductQuantity != 1)
            {
                cart.ProductQuantity--;
                await _context.SaveChangesAsync();
            }

            else
            {
                _context.Remove(cart);

                await _context.SaveChangesAsync();
            }


            return RedirectToAction("Cart", new
            {
                discountAmount = 0,
                discountType = 1,
                discountCode = ""
            });



        }




        public async Task<IActionResult> AddToCart(int id)
        {
            string userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            if (userId == null)
                return View("Error","Only reigtered users can buy our products. Sign up and enjoy our products");


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
                cart.ProductQuantity++;
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
        public IActionResult Cart(string discountAmount, string discountType, string discountCode = "")
        {

            double doubleVal = Double.Parse(discountAmount);
            int intVal = int.Parse(discountType);


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
            ViewBag.DiscountCode = discountCode;

            double totalAmountWithoutDiscount = 0;

            for (var i = 0; i < userCarts.Count; i++)
            {
                var cart = userCarts[i];
                var products = cartProducts[i];


                foreach (var product in products)
                {

                    totalAmountWithoutDiscount += (double)(product.Price * cart.ProductQuantity);
                }
            }

            double totalAmount = 0;

            if (intVal == 1)
                totalAmount = totalAmountWithoutDiscount - doubleVal;
            else
            {
                totalAmount = (totalAmountWithoutDiscount * (100 - doubleVal)) / 100;
            }

            ViewBag.TotalAmountToPay = totalAmount;

            return View();
        }

        public async Task<IActionResult> OrderCreate([Bind("Name,Price,personalMessage,DeliveryDate")] Order order, [Bind("DeliveryAddress,BankAccount,PaymentType,PayedAmount")] Payment payment, [Bind("DiscountCode")] Discount discount)
        {

            string userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            var existingCustomer = _context.Users.FirstOrDefault(m => m.Id == userId);
            if (userId == null)
            {
                return View("~/Views/Shared/Error.cshtml");
            }

            int? discId = null;
            double? doubleVal = null;
            double total = payment.PayedAmount;
            if (discount.DiscountCode != null)
            {
                int? discType = null;

                if (_discountCodeVerifier.VerifyDiscountCode(discount.DiscountCode))
                {
                    if (_discountCodeVerifier.VerifyExperationDate(discount.DiscountCode))
                    { discount = _discountCodeVerifier.GetDiscount(discount.DiscountCode);
                        discId = discount.DiscountID;
                        discType = (int)discount.DiscountType;
                        doubleVal = discount.DiscountAmount;
                    }
                }

                if (discType == 1)
                    total = (double)(total - doubleVal);
                else
                {
                    total = (double)(total*(100-doubleVal)/100);
                }


            }




            // Set up the payment instance
            Payment payment1 = new Payment
            {
                BankAccount = payment.BankAccount,
                DeliveryAddress = payment.DeliveryAddress,
                DiscountID = discId,
                PaymentType = payment.PaymentType,
                PayedAmount = payment.PayedAmount

            };

            // Save the payment instance to the database
            _context.Add(payment1);
            await _context.SaveChangesAsync();

            // Set up the payment instance
            Order order1 = new Order
            {
                DeliveryDate = order.DeliveryDate,
                CustomerID = userId,
                PaymentID = payment1.PaymentID,
                TotalAmountToPay = total,
                purchaseDate = DateTime.Now,
                personalMessage = order.personalMessage,
                IsOrderSent = false,  //moze se mijenjat
                Rating = null  //promjenila jer se rejta tek kasnije
            };

            // Save the subscription to the database
            _context.Add(order1);
            await _context.SaveChangesAsync();



            // Retrieve user-specific orders based on the CustomerId
            List<Cart> userCarts = _context.Cart
                .Where(o => o.CustomerID == userId)
                .ToList();

            // Get the associated products for each order
            List<List<Product>> cartProducts = GetCartProducts(userCarts);

            for (var i = 0; i < userCarts.Count; i++)
            {
                var cart = userCarts[i];
                var products = cartProducts[i];

                foreach (var product in products)
                {

                    ProductOrder productOrder1 = new ProductOrder
                    {
                        OrderID = order1.OrderID,
                        ProductID = product.ProductID,
                        ProductQuantity = cart.ProductQuantity
                    };

                    for (var k = 0; k < cart.ProductQuantity; k++)
                    {
                        ProductSales productSales1 = new ProductSales
                        {
                            SalesDate = DateTime.Now,
                            ProductID = product.ProductID

                        };
                        _context.Add(productSales1);
                        await _context.SaveChangesAsync();

                    }

                    _context.Add(productOrder1);
                    await _context.SaveChangesAsync();
                }
            }

            foreach (Cart cart in userCarts)
            {
                _context.Cart.Remove(cart);
            }

            _context.SaveChanges();

            return Redirect("/DtoRequests/ThankYou?orderType=order");
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
                BankAccount = payment.BankAccount,
                PayedAmount = subscription.Price,
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
                DeliveryDate = subscription.DeliveryDate,
                SubscriptionType = subsType,
                CustomerID = userId,
                PaymentID = payment1.PaymentID,
                Price = subscription.Price,
                personalMessage = subscription.personalMessage

            };


            // Save the subscription to the database
            _context.Add(subscription1);
            await _context.SaveChangesAsync();


            return Redirect("/DtoRequests/ThankYou?orderType=subscription");
        }


        public IActionResult ThankYou(string orderType)
        {
            ViewBag.OrderType = orderType;
            return View();
        }
    }
}



