using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ayana.Models
{
    public class Customer : Person
    {
        [Key]
        public int CustomerID { get; set; }

        public int BankAccount { get; set; }



        public Customer()
        {

        }

        
    }
}
