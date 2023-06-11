using Ayana.Data;
using System;

namespace Ayana.Paterni
{
    public class ReportFactory:IReportFactory
    {
        private readonly ApplicationDbContext _context;

        public ReportFactory(ApplicationDbContext context)
        {
            _context = context;
        }

        public IReport CreateReport(string type)
        {
            switch (type)
            {
                case "weekly":
                    return new WeeklyReport(_context);
                case "monthly":
                    return new MonthlyReport(_context);
                case "yearly":
                    return new YearlyReport(_context);
                default:
                    throw new ArgumentException("Nepodržan tip izvještaja.");
            }
        }

        
    }
}
