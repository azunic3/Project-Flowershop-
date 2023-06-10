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
    public class ProductEditor : IProduct
    {
        private readonly ApplicationDbContext _context;

        public ProductEditor(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task EditAll(Product product)
        {


            _context.Update(product);
            _context.SaveChanges();

        }

        public async Task EditNameAndPrice(int id, Product product)
        {

            // Retrieve the existing product from the database
            var existingProduct = _context.Products.Find(product.ProductID);

            // Update only the name and price attributes
            existingProduct.Name = product.Name;
            existingProduct.Price = product.Price;

            // Save the changes
            _context.Update(existingProduct);
            _context.SaveChanges();
        }

        public List<Product> GetAllProducts()
        {
            return _context.Products.ToList();
        }
    }
}
