using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ayana.Models
{
    public class CustomerOrder
    {
        [Key]
        public int CustomerOrderID { get; set; }

        [ForeignKey("Order")]
        public int OrderID { get; set; }
        public Order Order { get; set; }

        [ForeignKey("Customer")]
        public int CustomerID { get; set; }
        public Customer Customer { get; set; }

        CustomerOrder()
        {

        }
    }
}
