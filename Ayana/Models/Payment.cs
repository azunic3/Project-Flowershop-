using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ayana.Models
{
    public class Payment
    {
        [Key]
        public int PaymentID { get; set; }
        public PaymentType PaymentType { get; set; }

        [ForeignKey("Discount")]
        public int DiscountID { get; set; }
        public Discount Discount { get; set; }
        public double PayedAmount { get; set; }  //with discount
        public bool IsPaymentValid { get; set; }
        public string DeliveryAddress { get; set; }
        public int BankAccount { get; set; }

        public Payment()
        {

        }

    }
}
