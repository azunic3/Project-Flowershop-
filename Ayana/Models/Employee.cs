using Ayana.Data;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ayana.Models
{
    public class Employee: ApplicationUser
    {
        [ForeignKey("ApplicationUser")]
        public int AppUserId { get; set; }
        public string HomeAddress { get; set; }
        public DateTime DateOfBirth { get; set; }

        public Employee()
        {

        }

   
    }
}
