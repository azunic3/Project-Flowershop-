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
using Microsoft.AspNetCore.Authorization;
using System.Data;
using Ayana.Paterni;

namespace Ayana.Controllers
{
    public class ProductsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IProduct _productEditor;
        public ProductsController(ApplicationDbContext context, IProduct p)
        {
            _context = context;
            _productEditor = p;
        }

        // GET: Products
        public async Task<IActionResult> Index()
        {
            return View(await _context.Products.ToListAsync());
        }
       

       
        // GET: Products/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await _context.Products
                .FirstOrDefaultAsync(m => m.ProductID == id);
            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        // GET: Products/Create
        [Authorize(Roles = "Employee")]
        public IActionResult Create()
        {
            return View();
        }
        public IActionResult SearchResult(string search)
        {
            List<Product> products = _context.Products.ToList();
            if (search == null)
                return View(products);
            else
            {
                string pattern = $"{Regex.Escape(search)}";
                List<Product> searchResults = products.Where(p => Regex.IsMatch(p.Name, pattern, RegexOptions.IgnoreCase)).ToList();

                ViewBag.String = search;
                return View(searchResults);
            }
        }

        public IActionResult PopularSearches(string popularsearch)
        {
            List<Product> products = _context.Products.ToList();
            bool isItBAM = Regex.IsMatch(popularsearch, "BAM", RegexOptions.IgnoreCase);
            if (isItBAM)
            {
                int o = int.Parse(popularsearch.Substring(4).Split(".").First());
                List<Product> inPriceRange = products.FindAll(p => p.Price <= o);
                ViewBag.p = inPriceRange;
            }
            else
            {
                List<Product> categoryList = _context.Products.ToList().FindAll(x => x.Category.ToLower() == popularsearch.ToLower());

                if (categoryList.Count == 0)
                {
                    categoryList= _context.Products.ToList().FindAll(x => x.FlowerType.ToLower() == popularsearch.ToLower());

                }
                ViewBag.p = categoryList;
            }
            return View("~/Views/Products/SearchResult.cshtml", ViewBag.p);
        }
        [HttpGet]
        public ActionResult Sort(string sortOption, string String)
        {
            ISort sortStrategy;

            if (sortOption == "ascendingName")
            {
                sortStrategy = new AscendingNameSortStrategy();
            }
            else if (sortOption == "descendingName")
            {
                sortStrategy = new DescendingNameSortStrategy();
            }
            else if (sortOption == "ascendingPrice")
            {
                sortStrategy = new AscendingPriceSortStrategy();
            }
            else if (sortOption == "descendingPrice")
                sortStrategy = new DescendingPriceSortStrategy();
            else
                sortStrategy = new AscendingNameSortStrategy();
            string pattern = $"{Regex.Escape(String)}";
            List<Product> searchResults = _context.Products.ToList().Where(p => Regex.IsMatch(p.Name, pattern, RegexOptions.IgnoreCase)).ToList();
            ViewBag.String = String;
            var sortedProducts = sortStrategy.Sort(searchResults);
            ViewBag.SelectedSortOption = sortOption;

            return PartialView("~/Views/Products/SearchResult.cshtml", sortedProducts);
        }
        // POST: Products/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Employee")]

        public async Task<IActionResult> Create([Bind("ProductID,Name,Price,Stock,SalesHistory,Category,Description")] Product product)
        {
            if (ModelState.IsValid)
            {
                _context.Add(product);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(product);
        }

        // GET: Products/Edit/5
        [Authorize(Roles = "Employee")]

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await _context.Products.FindAsync(id);
            if (product == null)
            {
                return NotFound();
            }
            return View(product);
        }
        // POST: Products/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Employee")]

        public async Task<IActionResult> Edit(int id, [Bind("ProductID,Name,Price,Stock,Category,Description,ImageUrl,FlowerType")] Product product)
        {
            if (id != product.ProductID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _productEditor.EditAll(product);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProductExists(product.ProductID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                var AllProducts = _context.Products.ToList();
                return View("~/Views/Home/Index.cshtml", AllProducts);
            }

            return View("~/Views/Home/Index.cshtml");
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Employee")]

        public async Task<IActionResult> EditNameAndPrice(int id, [Bind("ProductID,Name,Price")] Product product)
        {
            if (id != product.ProductID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _productEditor.EditNameAndPrice(id, product);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProductExists(product.ProductID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                var AllProducts = _context.Products.ToList();
                return View("~/Views/Home/Index.cshtml", AllProducts);
            }

            return View("~/Views/Home/Index.cshtml");
        }



        // GET: Products/Delete/5
        [Authorize(Roles = "Employee")]

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await _context.Products
                .FirstOrDefaultAsync(m => m.ProductID == id);
            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        // POST: Products/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Employee")]

        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var product = await _context.Products.FindAsync(id);
            _context.Products.Remove(product);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProductExists(int id)
        {
            return _context.Products.Any(e => e.ProductID == id);
        }

    }
}
