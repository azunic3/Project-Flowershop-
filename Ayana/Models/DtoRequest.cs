using System.ComponentModel.DataAnnotations;
using Ayana.Data;

namespace Ayana.Models
{
    public class DtoRequest
    {
        [Key]
        public int DtoRequestID { get; set; }
        public Subscription subscription { get; set; }
        public Payment payment { get; set; }

        public Order order { get; set; }

        public Discount discount { get; set; }

        public Product product { get; set; }
        public ProductOrder productOrder{ get; set; }

        public ProductSales productSales { get; set; }

        public ApplicationUser customer{ get; set; }

        public Cart cart { get; set; }

    }
}
