using Microsoft.AspNetCore.Authentication.OAuth.Claims;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ayana.Models
{
    
    public class Order
    {
        [Key]
        public int OrderID { get; set; }

        [ForeignKey("Payment")]
        public int PaymentID { get; set; }
        public Payment Payment { get; set; }

       
        public Customer Customer{ get; set; }


        public bool IsOrderSent { get; set; }
        public double Rating { get; set; }
        public double TotalAmountToPay { get; set; } //without discount
        public DateTime DeliveryDate { get; set; }

        public Order()
        {

        }

        
    }
}
