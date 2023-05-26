using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.VisualBasic;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ayana.Models
{
    public class Subscription
    {

        [Key]
        public int SubscriptionID { get; set; }
        public string Name { get; set; }
        public SubscriptionType SubscriptionType { get; set; }
        public DateTime DeliveryDate { get; set; }
        public double Price { get; set; }

        [ForeignKey("Customer")]
        public int CustomerID { get; set; }
        public Customer Customer { get; set; }

        [ForeignKey("Payment")]
        public int PaymentID { get; set; }
        public Payment Payment { get; set; }

        public Subscription()
        {

        }

    }
}
