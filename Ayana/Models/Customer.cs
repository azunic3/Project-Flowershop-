using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ayana.Models
{
    public class Customer : Person
    {
       
        public int BankAccount { get; set; }

        public Customer()
        {

        }

        
    }
}
