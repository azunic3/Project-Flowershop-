using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace Ayana.Models
{
    
    public  class Person : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }


        public Person()
        {

        }

   
    }
}
