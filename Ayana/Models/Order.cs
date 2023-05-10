using Microsoft.AspNetCore.Authentication.OAuth.Claims;
using Microsoft.VisualBasic;
using System.Collections.Generic;
namespace Ayana.Models
{
    
    public class Order
    {
        double totalAmountToPay;
        DateAndTime deliveryDate;
        Dictionary<Product, int> quantityAndTypeOrdered = new Dictionary<Product, int>();
        Customer customer;
        bool isOrderSent;
        double rating;
        Payment payment;

        public Order()
        {

        }

        public double TotalAmountToPay { get => totalAmountToPay; set => totalAmountToPay = value; }
        public DateAndTime DeliveryDate { get => deliveryDate; set => deliveryDate = value; }
        public Customer Customer { get => customer; set => customer = value; }
        public bool IsOrderSent { get => isOrderSent; set => isOrderSent = value; }
        public double Rating { get => rating; set => rating = value; }
        public Payment Payment { get => payment; set => payment = value; }
        public Dictionary<Product, int> QuantityAndTypeOrdered { get => quantityAndTypeOrdered; set => quantityAndTypeOrdered = value; }
    }
}
