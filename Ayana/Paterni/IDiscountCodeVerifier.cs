using Ayana.Models;

namespace Ayana.Paterni
{
    public interface IDiscountCodeVerifier
    {
        bool VerifyDiscountCode(string discountCode);
        bool VerifyExperationDate(string discountCode);
        Discount GetDiscount(string discountCode);
    }
}
