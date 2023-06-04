using System;
using System.ComponentModel.DataAnnotations;

namespace Ayana.Models
{
    public class ProductSales
    {
        [Key]
        public int ProductSalesID { get; set; }

        public DateTime SalesDate { get; set; }

        public ProductSales()
        {

        }


    }
}
