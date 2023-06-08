using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Ayana.Data;

namespace Ayana.Models
{
    public class Subscription
    {

        [Key]
        public int SubscriptionID { get; set; }
        public string Name { get; set; } 
        public SubscriptionType SubscriptionType { get; set; }

        [DisplayName("Delivery date")]
        public DateTime DeliveryDate { get; set; }
        public double Price { get; set; }

        [ForeignKey("ApplicationUser")]
        public string CustomerID { get; set; }
        public ApplicationUser ApplicationUser { get; set; }

        [ForeignKey("Payment")]
        public int PaymentID { get; set; }
        public Payment Payment { get; set; }

        [DisplayName("Personal message")]
        public string? personalMessage { get; set; }
        public Subscription()
        {

        }

    }
}
