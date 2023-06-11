using Ayana.Data;
using OfficeOpenXml.Drawing.Chart;
using OfficeOpenXml;
using System.Linq;
using System;
using OfficeOpenXml.Table;

namespace Ayana.Paterni
{
    public class MonthlyReport : IReport
    {

        private readonly ApplicationDbContext _context;

        public MonthlyReport(ApplicationDbContext context)
        {
            _context = context;
        }

        public byte[] GenerateReport()
        {
            var salesData = _context.ProductSales.ToList();
            var products = _context.Products.ToList();
            DateTime oneMonthAgo = DateTime.Today.AddMonths(-1);

            var productData = salesData.Where(s => s.SalesDate >= oneMonthAgo) // Filter sales data for products sold 7 days ago or earlier
    .GroupBy(s => s.ProductID).Select(g => new
    {
        ProductName = products.FirstOrDefault(x => x.ProductID == g.Key).Name,
        ProductID = g.Key,
        Quantity = g.Count(),
        Revenue = g.Sum(s => (products.FirstOrDefault(x => x.ProductID == g.Key).Price))
    }).ToList();
            var notSoldProducts=products.Where(x =>!productData.Any(p => p.ProductID == x.ProductID)).ToList();
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;

            // Create the Excel package
            using (var package = new ExcelPackage())
            {
                // Add a worksheet for the weekly report
                var worksheet = package.Workbook.Worksheets.Add("Monthly Report");
                var tableRange = worksheet.Cells[1, 1, productData.Count() + notSoldProducts.Count() + 1, 3];
                var table = worksheet.Tables.Add(tableRange, "ProductTable");

                // Format the table style
                table.TableStyle = TableStyles.Light9;
                // Set the column headers for product revenue
                worksheet.Cells[1, 1].Value = "Product";
                worksheet.Cells[1, 2].Value = "Revenue";
                worksheet.Cells[1, 3].Value = "Stock";

                // Populate the data for product revenue in the worksheet
                for (int i = 0; i < productData.Count(); i++)
                {
                    worksheet.Cells[i + 2, 1].Value = productData[i].ProductName;
                    worksheet.Cells[i + 2, 2].Value = productData[i].Revenue;
                    worksheet.Cells[i + 2, 3].Value = productData[i].Quantity;

                }
                for (int i = productData.Count(); i < notSoldProducts.Count(); i++)
                {
                    worksheet.Cells[i  , 1].Value = notSoldProducts[i - productData.Count()].Name;
                    worksheet.Cells[i  , 2].Value = 0;
                    worksheet.Cells[i, 3].Value = notSoldProducts[i - productData.Count()].Stock;
                }
                // Add a total row for revenue
                var totalRow = worksheet.Cells[productData.Count() + notSoldProducts.Count() + 2, 1, productData.Count() + notSoldProducts.Count() + 2, 3];
                totalRow.Merge = true;
                totalRow.Value = "Total";
                totalRow.Style.Font.Bold = true;

                worksheet.Cells[productData.Count() + notSoldProducts.Count() + 2, 2].Formula = $"SUM(B2:B{productData.Count() + notSoldProducts.Count() + 1})";

                worksheet.Cells.AutoFitColumns();

                // Create the bar chart for product revenue
                var barChart = worksheet.Drawings.AddChart("ProductRevenueChart", eChartType.BarClustered);
                barChart.SetPosition(4, 0, 6, 0);
                barChart.SetSize(600, 400);
                barChart.Title.Text = "Monthly Report: Revenue by Product";
                var barSeries = (ExcelBarChartSerie)barChart.Series.Add(worksheet.Cells["B2:B" + (productData.Count + 1+ notSoldProducts.Count())], worksheet.Cells["A2:A" + (productData.Count + 1+notSoldProducts.Count())]);
                barChart.XAxis.Title.Text = "Product";
                barChart.YAxis.Title.Text = "Revenue";

                // Save the Excel package as a byte array
                return package.GetAsByteArray();
            }
        }
    }


}
