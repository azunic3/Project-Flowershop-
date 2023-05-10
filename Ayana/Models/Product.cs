using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;

namespace Ayana.Models
{
    public class Product
    {
        string name;
        double price;
        int stock;
        int salesHistory;
        string category;
        string description;
        List<string> subcategoryList = new List<string>();
        //best seller
       
        
            public Product()
        {

        }

        public string Name { get => name; set => name = value; }
        public double Price { get => price; set => price = value; }
        public int Stock { get => stock; set => stock = value; }
        public int SalesHistory { get => salesHistory; set => salesHistory = value; }
        public string Category { get => category; set => category = value; }
        public string Description { get => description; set => description = value; }
        public List<string> SubcategoryList { get => subcategoryList; set => subcategoryList = value; }
    }
}
