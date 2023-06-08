using System.ComponentModel.DataAnnotations;

namespace Ayana.Models
{
    public enum PaymentType
    {
        [Display(Name = "Cash")]
        Cash,

        [Display(Name = "Credit card")]
        CreditCard
       
    }
}
