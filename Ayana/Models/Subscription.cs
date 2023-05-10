using Microsoft.VisualBasic;

namespace Ayana.Models
{
    public class Subscription
    {
        string name;
        SubscriptionType subscriptionType;
        DateAndTime deliveryDate;
        double price;
        Customer customer;
        Payment payment;

        public Subscription()
        {

        }

        public string Name { get => name; set => name = value; }
        public SubscriptionType SubscriptionType { get => subscriptionType; set => subscriptionType = value; }
        public DateAndTime DeliveryDate { get => deliveryDate; set => deliveryDate = value; }
        public double Price { get => price; set => price = value; }
        public Customer Customer { get => customer; set => customer = value; }
        public Payment Payment { get => payment; set => payment = value; }
    }
}
