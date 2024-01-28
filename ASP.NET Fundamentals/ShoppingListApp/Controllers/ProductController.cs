using Microsoft.AspNetCore.Mvc;
using ShoppingListApp.Contracts;
using ShoppingListApp.Models;

namespace ShoppingListApp.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        public async Task<IActionResult> Index()
        {
            var model = await _productService.GetAllAsync();

            return View(model);
        }

        [HttpGet]
        public IActionResult Add()
        {
            var model = new ProductViewModel(); //This is how where we create a new instance of the ProductViewModel

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Add(ProductViewModel model)
        {
            if (ModelState.IsValid == false)
            {
                return View(model);
            }

            await _productService.AddProductAsync(model);

            return RedirectToAction(nameof(Index));

        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var model = await _productService.GetByIdAsync(id);

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, ProductViewModel model)
        {
            if (ModelState.IsValid == false || model.Id != id)
            {
                return View(model);
            }

            await _productService.UpdateProductAsync(model);

            return RedirectToAction(nameof(Index));
        }


        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            // Check if the product exists
            var existingProduct = await _productService.GetByIdAsync(id);

            if (existingProduct == null)
            {
                // Handle the case where the product with the given id is not found
                return NotFound();
            }

            // Perform the deletion
            await _productService.DeleteProductAsync(id);

            return RedirectToAction(nameof(Index));
        }
    }
}
