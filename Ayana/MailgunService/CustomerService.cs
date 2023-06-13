using Ayana.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Ayana.MailgunService
{
    public class CustomerService : ICustomerService
    {
        private readonly ApplicationDbContext _context;

        public CustomerService(ApplicationDbContext context)
        {
            _context = context;
        }

        public List<ApplicationUser> GetInactiveCustomers()
        {
            var cutoffDate = DateTime.Now.AddDays(30); // Get customers inactive for 30 days or more
            var orders=_context.Orders.Where(x=>x.purchaseDate<=cutoffDate).ToList();
            Console.WriteLine("Uslo");
            var inactiveCustomers = _context.Users.Where(x => orders.Any(a => a.CustomerID == x.Id)).ToList();
            return inactiveCustomers;
        }
    }
}
