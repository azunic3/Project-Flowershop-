using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Ayana.Data;
using Ayana.Models;
using Microsoft.Extensions.FileSystemGlobbing.Internal;
using System.Text.RegularExpressions;
using static Humanizer.On;
using Ayana.Patterns;
namespace Ayana.Patterns
{
    public interface IProduct
    {
        Task EditAll(Product product);
        Task EditNameAndPrice(int id, Product product);
        List<Product> GetAllProducts();

    }
}
