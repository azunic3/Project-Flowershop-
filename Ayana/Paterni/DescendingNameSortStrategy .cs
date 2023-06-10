using Ayana.Models;
using System.Collections.Generic;
using System.Linq;

namespace Ayana.Paterni
{
    public class DescendingNameSortStrategy : ISort
    {
        public List<Product> Sort(List<Product> products)
        {
            List<Product> sortedProducts = products.OrderByDescending(p => p.Name).ToList();
            return sortedProducts;
        }
    }
}
