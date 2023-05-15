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

        //this will use in a method that creates a list of history orders

        [ForeignKey("Order")]
        public int OrderID { get; set; }


        //List<Order> HistoryOfOrders = new List<Order>(); 


        public Customer()
        {

        }

        
    }
}
