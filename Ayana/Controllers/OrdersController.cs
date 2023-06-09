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

namespace Ayana.Controllers
{
    public class OrdersController : Controller
    {
        private readonly ApplicationDbContext _context;

        public OrdersController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Orders
        public async Task<IActionResult> Index()
        {
            return View(await _context.Orders.ToListAsync());
        }

        public List<List<Product>> GetOrderProducts(List<Order> orders)
        {
            List<List<Product>> orderProducts = new List<List<Product>>();

            foreach (var order in orders)
            {
                var products = _context.ProductOrders
                    .Where(po => po.OrderID == order.OrderID)
                    .Select(po => po.Product)
                    .ToList();

                orderProducts.Add(products);
            }

            return orderProducts;
        }


        public IActionResult UserOrders()
        {
            var p1 = _context.Users.ToList();
            string userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            // Retrieve user-specific orders based on the CustomerId
            List<Order> userOrders = _context.Orders
                .Include(o => o.Payment)
                .Where(o => o.CustomerID == userId)
                .ToList();
            // Get the associated products for each order
            List<List<Product>> orderProducts = GetOrderProducts(userOrders);

            // Pass the userOrders and orderProducts to the view
            ViewBag.UserOrders = userOrders.OrderBy(order => order.Rating).ToList(); ;
            ViewBag.OrderProducts = orderProducts;

            // Render the view
            return View();
        }


        // GET: Orders/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var order = await _context.Orders
                .FirstOrDefaultAsync(m => m.OrderID == id);
            if (order == null)
            {
                return NotFound();
            }

            return View(order);
        }

        // GET: Orders/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Orders/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("OrderID,CustomerID,PaymentID,IsOrderSent,Rating,TotalAmountToPay,DeliveryDate")] Order order)
        {
            if (ModelState.IsValid)
            {
                _context.Add(order);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(order);
        }



        // POST: Orders/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit([Bind("OrderID,Rating")] Order order)
        {
            var o = _context.Orders.ToList();
            var existingOrder = o.Find(m => m.OrderID == order.OrderID);

            existingOrder.Rating = order.Rating;
            _context.SaveChanges();
            return Redirect("/Orders/UserOrders");
        }

        // GET: Orders/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var order = await _context.Orders
                .FirstOrDefaultAsync(m => m.OrderID == id);
            if (order == null)
            {
                return NotFound();
            }

            return View(order);
        }

        // POST: Orders/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var order = await _context.Orders.FindAsync(id);
            _context.Orders.Remove(order);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool OrderExists(int id)
        {
            return _context.Orders.Any(e => e.OrderID == id);
        }
    }
}
