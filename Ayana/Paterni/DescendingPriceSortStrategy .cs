using Ayana.Models;
using System.Collections.Generic;
using System.Linq;

namespace Ayana.Paterni
{
    public class DescendingPriceSortStrategy : ISort
    {
        public List<Product> Sort(List<Product> products)
        {
            List<Product> sortedProducts = products.OrderByDescending(p => p.Price).ToList();
            return sortedProducts;
        }
    }
}
