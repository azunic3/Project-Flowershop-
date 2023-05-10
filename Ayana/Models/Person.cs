namespace Ayana.Models
{
    
    public abstract class Person
    {
        string firstName;
        string lastName;
        string password;
        string email;

        public Person()
        {

        }

        public string FirstName { get => firstName; set => firstName = value; }
        public string LastName { get => lastName; set => lastName = value; }
        public string Password { get => password; set => password = value; }
        public string Email { get => email; set => email = value; }
    }
}
