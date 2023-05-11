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
        public ReportType reportType { get; set; }
        public DateTime date { get; set; }

        [ForeignKey("Employee")]
        public int EmployeeID { get; set; }

        public Report()
        {

        }

     
    }
}
