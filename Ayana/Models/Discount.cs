using Microsoft.VisualBasic;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Ayana.Models
{
    public class Discount
    {
        [Key]
        public int DiscountID { get; set; }

        [DisplayName("Discount code")]
        public string DiscountCode { get; set; }

        public double DiscountAmount { get; set; }
        public DiscountType DiscountType { get; set; }
        public DateTime DiscountBegins { get; set; }
        public DateTime DiscountEnds { get; set; }
        public Discount()
        {

        }

       
    } 
    
}
