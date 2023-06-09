using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Ayana.Data;

namespace Ayana.Models
{
    public class Cart
    {
        [Key]
        public int CartID { get; set; }

        [ForeignKey("Product")]
        public int ProductID { get; set; }
        public Product Product{ get; set; }

        [ForeignKey("Customer")]
        public string CustomerID { get; set; }
        public ApplicationUser Customer { get; set; }

        public int? ProductQuantity { get; set; }


        public Cart()
        {

        }
    }
}
