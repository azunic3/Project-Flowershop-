namespace Ayana.Models
{
    public class Customer : Person
    {
        int id;
        bool subscription;
        int bankAccount;

        public Customer()
        {

        }

        public int Id { get => id; set => id = value; }
        public int BankAccount { get => bankAccount; set => bankAccount = value; }
        public bool Subscription { get => subscription; set => subscription = value; }
    }
}
