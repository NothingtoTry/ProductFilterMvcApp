using Microsoft.AspNetCore.Mvc;
using ProductFilterMvcApp.Models;

namespace ProductFilterMvcApp.Controllers
{
    public class ProductController : Controller
    {
        private static List<Product> products = new List<Product>
        {
            new Product("Apple", Color.Green, Size.Small),
            new Product("Tree", Color.Green, Size.Large),
            new Product("House", Color.Blue, Size.Large)
        };

        private BetterFilter _filter = new BetterFilter();

        // GET: Product
        public IActionResult Index()
        {
            return View(products);
        }

        // POST: Product/Add
        [HttpPost]
        public IActionResult Add(string name, Color color, Size size)
        {
            var newProduct = new Product(name, color, size);
            products.Add(newProduct);
            return RedirectToAction("Index");
        }

        // POST: Product/Filter
        [HttpPost]
        public IActionResult Filter(Color color, Size size)
        {
            var colorSpec = new ColorSpecification(color);
            var sizeSpec = new SizeSpecification(size);
            var andSpec = new AndSpecification<Product>(colorSpec, sizeSpec);  // Use AndSpecification here

            var filteredProducts = _filter.Filter(products, andSpec).ToList();
            return View("Index", filteredProducts);
        }
    }
}
