using Ayana.Data;
using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ayana.Models
{
    public class Customer : ApplicationUser
    {
        [ForeignKey("ApplicationUser")]
        public int AppUserId { get; set; }
        public int BankAccount { get; set; }

        public Customer()
        {

        }

        
    }
}
