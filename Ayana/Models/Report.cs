using Microsoft.VisualBasic;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ayana.Models
{
    public class Report
    {
        [Key]
        public int ReportID { get; set; }
        public ReportType ReportType { get; set; }
        public DateTime Date { get; set; }

        [ForeignKey("Employee")]
        public string EmployeeId { get; set; }
        public Employee Employee { get; set; }
        public Report()
        {

        }

     
    }
}
