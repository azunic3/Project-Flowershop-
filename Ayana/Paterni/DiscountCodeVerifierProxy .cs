using Ayana.Models;

namespace Ayana.Paterni
{
    public class DiscountCodeVerifierProxy:IDiscountCodeVerifier
    {
        private readonly IDiscountCodeVerifier _discountCodeVerifier;

        public DiscountCodeVerifierProxy(IDiscountCodeVerifier discountCodeVerifier)
        {
            _discountCodeVerifier = discountCodeVerifier;   
        }

        public Discount GetDiscount(string discountCode)
        {
            return _discountCodeVerifier.GetDiscount(discountCode);        }

        public bool VerifyDiscountCode(string discountCode)
        {
                        
            return _discountCodeVerifier.VerifyDiscountCode(discountCode);
        }
        public bool VerifyExperationDate(string discountCode)
        {
            return _discountCodeVerifier.VerifyExperationDate(discountCode);
        }
    }
}
