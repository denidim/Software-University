using Microsoft.AspNetCore.Mvc;
using WebShopDemo.Core.Contracts;
using WebShopDemo.Core.Data.Common;
using WebShopDemo.Core.Data.Models;
using WebShopDemo.Core.Models;

namespace WebShopDemo.Controllers
{
    //REST api/product
    [Route("api/[controller]")]
    [ApiController]
    public class ProductApiController : ControllerBase
    {
        private readonly IProductService productService;

        public ProductApiController(IProductService productService)
        {
            this.productService = productService;
        }

        [HttpGet]
        public async Task<IActionResult> GetProduct()
        {
            return Ok(await productService.GetAll());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetProduct(Guid id)
        {
            var product = await productService.GetForEditAsync(id);
            if(product == null) return NotFound();
            return Ok(product);
        }

        [HttpPost]
        public async Task<ActionResult> Post(ProductDto product)
        {
            await productService.AddAsync(product);

            return CreatedAtAction("Get", new { id = product.Id }, product);
        }

        [HttpPut]
        public async Task<ActionResult> Put(ProductDto product)
        {
            await productService.EditAsync(product);

            return Ok(product);
        }

        public async Task<ActionResult> Delete(Guid id)
        {
            await productService.Delete(id);

            return NoContent();
        }
    }
}
