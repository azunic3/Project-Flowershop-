using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace Ayana.Models
{
    public enum PaymentType
    {
        [Display(Name = "Credit card")]
        CreditCard,
        [Display(Name = "Cash")]
        Cash
    }
}
