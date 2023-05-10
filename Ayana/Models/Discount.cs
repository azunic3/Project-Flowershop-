using Microsoft.VisualBasic;

namespace Ayana.Models
{
    public class Discount
    {
        string discountCode; 
        double discountAmount;
        DiscountType discountType;
        DateAndTime discountBegins;
        DateAndTime discountEnds;
        public Discount()
        {

        }

        public string DiscountCode { get => discountCode; set => discountCode = value; }
        public double DiscountAmount { get => discountAmount; set => discountAmount = value; }
        public DiscountType DiscountType { get => discountType; set => discountType = value; }
        public DateAndTime DiscountBegins { get => discountBegins; set => discountBegins = value; }
        public DateAndTime DiscountEnds { get => discountEnds; set => discountEnds = value; }
    } 
    
}
