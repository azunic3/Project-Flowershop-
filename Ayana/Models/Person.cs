using Ayana.Data;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ayana.Models
{
    
    public   class Person
    {
        [Key]
        public virtual int PersonId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        [ForeignKey("ApplicationUser")]
        public string ApplicationUserId { get; set; } 
        public ApplicationUser ApplicationUser { get; set; }
        public Person()
        {

        }

   
    }
}
