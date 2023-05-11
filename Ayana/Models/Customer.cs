using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ayana.Models
{
    public class Customer : Person
    {
        [Key]
        public int CustomerID { get; set; }

        [ForeignKey("Subscription")]
        public int SubscriptionID { get; set; }
        public int BankAccount { get; set; }

        //List<Order> HistoryOfOrders = new List<Order>();



        public Customer()
        {

        }

        
    }
}
