using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebShopDemo.Core.Contracts;
using WebShopDemo.Core.Models;

namespace WebShopDemo.Controllers
{
    /// <summary>
    /// Web shop products
    /// </summary>
    [Authorize]
    public class ProductController : Controller
    {
        private readonly IProductService productService;

        public ProductController(IProductService _productService)
        {
            productService = _productService;
        }

        /// <summary>
        /// List all products
        /// </summary>
        /// <returns></returns>
        [AllowAnonymous]
        public async Task<IActionResult> Index()
        {
            ViewData["Title"] = "Products";

            var products = await productService.GetAll();

            return View(products);
        }

        [HttpGet]
        public IActionResult Add()
        {
            var model = new ProductDto();

            ViewData["Title"] = "Add new Product";

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Add(ProductDto model)
        {
            ViewData["Title"] = "Add new Product";

            if (!ModelState.IsValid)
            {
                return View(model);
            }

            await productService.Add(model);

            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public async Task<IActionResult> Delete([FromForm]string id)
        {
            var guidId = Guid.Parse(id);
            await productService.Delete(guidId);

            return RedirectToAction(nameof(Index));
        }
    }
}
