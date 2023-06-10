using Ayana.Models;
using System.Collections.Generic;

namespace Ayana.Paterni
{
    public interface ISort
    {
        List<Product> Sort(List<Product> products);
    }
}
