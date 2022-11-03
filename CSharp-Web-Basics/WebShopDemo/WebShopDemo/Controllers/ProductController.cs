using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebShopDemo.Core.Constants;
using WebShopDemo.Core.Contracts;
using WebShopDemo.Core.Models;

namespace WebShopDemo.Controllers
{
    /// <summary>
    /// Web shop products
    /// </summary>
    public class ProductController : BaseController
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
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            ViewData["Title"] = "Products";

            var products = await productService.GetAll();

            return View(products);
        }

        [HttpGet]
        [Authorize(Roles = $"{RoleConstants.Manager}")]
        public IActionResult Add()
        {
            var model = new ProductDto();

            ViewData["Title"] = "Add new Product";

            return View(model);
        }

        [HttpPost]
        [Authorize(Roles = $"{RoleConstants.Manager}")]
        public async Task<IActionResult> Add(ProductDto model)
        {
            ViewData["Title"] = "Add new Product";

            if (!ModelState.IsValid)
            {
                return View(model);
            }

            await productService.AddAsync(model);

            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        [Authorize(Policy = "CanDeleteProduct")]
        public async Task<IActionResult> Delete([FromForm]string id)
        {
            var guidId =  Guid.Parse(id);
            await productService.Delete(guidId);

            return RedirectToAction(nameof(Index));
        }


        [HttpGet]
        [Authorize(Roles = RoleConstants.Manager)]
        public async Task<IActionResult> Edit(Guid id)
        {
            var model =await productService.GetForEditAsync(id);

            return View(model);
        }


        [HttpPost]
        [Authorize(Roles = RoleConstants.Manager)]
        public async Task<IActionResult> Edit(ProductDto model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            await productService.EditAsync(model);

            return RedirectToAction(nameof(Index));
        }


    }
}
