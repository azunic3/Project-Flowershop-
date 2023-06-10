using Ayana.Models;
using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using Ayana.Paterni;
namespace Ayana.Paterni
{
    public class ProductSorter
    {
        private ISort _sortStrategy;

        public void SetSortStrategy(ISort sortStrategy)
        {
            _sortStrategy = sortStrategy;
        }

    
            public List<Product> Sort(List<Product> products, string sortOption)
            {
                Dictionary<string, ISort> sortStrategyMap = new Dictionary<string, ISort>()
    {
        { "AscendingName", new AscendingNameSortStrategy() },
        { "DescendingName", new DescendingNameSortStrategy() },
        { "AscendingPrice", new AscendingPriceSortStrategy() },
        { "DescendingPrice", new DescendingPriceSortStrategy() }
    };

                if (string.IsNullOrEmpty(sortOption) || !sortStrategyMap.ContainsKey(sortOption))
                {
                    // Default sort strategy (ascending by name)
                    sortOption = "AscendingName";
                }
                else
                _sortStrategy = sortStrategyMap[sortOption];
                return _sortStrategy.Sort(products);
            }

        }
    }
