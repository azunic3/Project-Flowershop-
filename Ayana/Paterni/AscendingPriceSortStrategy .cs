using Ayana.Models;
using System.Collections.Generic;
using System.Linq;

namespace Ayana.Paterni
{
    public class AscendingPriceSortStrategy : ISort
    {
        public List<Product> Sort(List<Product> products)
        {
            List<Product> sortedProducts = products.OrderBy(p => p.Price).ToList();
            return sortedProducts;
        }
    }
}
