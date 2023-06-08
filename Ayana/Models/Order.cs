using Microsoft.AspNetCore.Authentication.OAuth.Claims;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using Ayana.Data;
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

        [ForeignKey("Customer")]
        public string CustomerID { get; set; }
        public ApplicationUser Customer{ get; set; }

        public string? personalMessage { get; set; }

        public bool IsOrderSent { get; set; }
        public double? Rating { get; set; }
        public double TotalAmountToPay { get; set; } //without discount

        [DisplayName("Delivery date")]
        public DateTime DeliveryDate { get; set; }

        public Order()
        {

        }

        
    }
}
