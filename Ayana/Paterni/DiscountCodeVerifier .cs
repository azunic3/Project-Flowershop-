using Ayana.Data;
using Ayana.Models;
using System.Linq;
using System;
using Microsoft.EntityFrameworkCore;

namespace Ayana.Paterni
{
    public class DiscountCodeVerifier:IDiscountCodeVerifier
    {
        ApplicationDbContext _context;
        public DiscountCodeVerifier(ApplicationDbContext context)
        {
            _context = context;
        }

        public Discount GetDiscount(string discountCode)
        {
            return _context.Discounts.FirstOrDefault(x => x.DiscountCode == discountCode);
        }

        public bool VerifyDiscountCode(string discountCode)
        {
            var discount = _context.Discounts.FirstOrDefault(d => d.DiscountCode == discountCode);
            if (discount == null)
            {
                return false; // Kod za popust ne postoji
            }

           

            return true; 
        }
        public bool VerifyExperationDate(string discountCode)
        {
            var discount = _context.Discounts.FirstOrDefault(d => d.DiscountCode == discountCode);

            DateTime currentDate = DateTime.Now;
            if (currentDate < discount.DiscountBegins || currentDate > discount.DiscountEnds)
            {
                return false;             }
            return true;

        }
    }
}
