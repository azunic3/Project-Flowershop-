using Microsoft.VisualBasic;

namespace Ayana.Models
{
    public class Report
    {
        ReportType reportType;
        DateAndTime date;
        Employee employee;
        public Report()
        {

        }

        public ReportType ReportType { get => reportType; set => reportType = value; }
        public DateAndTime Date { get => date; set => date = value; }
        public Employee Employee { get => employee; set => employee = value; }
    }
}
