using System.ComponentModel.DataAnnotations;

namespace Ayana.Models
{
    
    public abstract class Person
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }

        public Person()
        {

        }

   
    }
}
