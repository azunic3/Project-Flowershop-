using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ayana.Models
{
    public class Payment
    {
        [Key]
        public int PaymentID { get; set; }

        [DisplayName("How would you like to pay?")]
        [EnumDataType(typeof(PaymentType))]
        public PaymentType PaymentType { get; set; }

        [ForeignKey("Discount")]
        public int? DiscountID { get; set; }
        public Discount? Discount { get; set; }
        public double PayedAmount { get; set; }  //with discount if it exists

        [DisplayName("Delivery address")]
        public string DeliveryAddress { get; set; }

        [DisplayName("Card number")]
        public int? BankAccount { get; set; } 

        public Payment()
        {

        }

    }
}
