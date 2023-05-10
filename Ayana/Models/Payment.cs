namespace Ayana.Models
{
    public class Payment
    {
        PaymentType paymentType;
        Discount discount;
        bool isPaymentValid;
        string deliveryAddress;

        public Payment()
        {

        }

        public PaymentType PaymentType { get => paymentType; set => paymentType = value; }
        public Discount Discount { get => discount; set => discount = value; }
        public bool IsPaymentValid { get => isPaymentValid; set => isPaymentValid = value; }
        public string DeliveryAddress { get => deliveryAddress; set => deliveryAddress = value; }
    }
}
