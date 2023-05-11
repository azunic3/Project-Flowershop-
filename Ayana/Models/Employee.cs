using System;
using System.ComponentModel.DataAnnotations;

namespace Ayana.Models
{
    public class Employee: Person
    {
        [Key]
        public int EmployeeID { get; set; }
        public string PhoneNumber { get; set; }
        public string HomeAddress { get; set; }
        public DateTime DateOfBirth { get; set; }

        public Employee()
        {

        }

   
    }
}
