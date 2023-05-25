using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ayana.Models
{
    public class Customer : Person
    {
        [Key]
        public int CustomerID { get; set; }

        public int BankAccount { get; set; }

        //this will use in a method that creates a list of history orders and subscriptions


        //public List<Subscription> HistoryOfSubscriptions { get; set; } = new List<Subscription>();

        //public List<Order> HistoryOfOrders { get; set; } = new List<Order>(); 


        public Customer()
        {

        }

        
    }
}
