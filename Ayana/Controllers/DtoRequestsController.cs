using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Ayana.Data;
using Ayana.Models;

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

        // POST: DtoRequests/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Name")] Subscription subscription, [Bind("DeliveryAddress")] Payment payment)
        {
            // TODO - create a payment -> p -> p.Id ->
            // TODO - pass the subscription and the paymentId
            return View();
        }
    }
}
