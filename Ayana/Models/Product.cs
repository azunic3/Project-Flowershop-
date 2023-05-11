using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Security.Cryptography.X509Certificates;

namespace Ayana.Models
{
    public class Product
    {
        [Key]
        public int ProductID { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public int Stock { get; set; }
        public int SalesHistory { get; set; }
        public string Category { get; set; }
        public string Description { get; set; }

        List<string> subcategoryList = new List<string>();
        //best seller
       
        
            public Product()
        {

        }

  
    }
}
