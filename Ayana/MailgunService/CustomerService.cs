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

        public System.Collections.Generic.List<ApplicationUser> GetInactiveCustomers()
        {
            var cutoffDate = DateTime.Now.AddDays(-30); // Get customers inactive for 30 days or more
            List<ApplicationUser> inactiveCustomers=_context.Users.ToList();//= _context.Orders.ToList();
            return inactiveCustomers;
        }
    }
}
