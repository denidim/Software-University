using Microsoft.AspNetCore.Mvc;
using WebShopDemo.Core.Data.Models;

namespace WebShopDemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductApiController : Controller
    {
        [HttpGet]
        public Product Test()
        {
            return new Product()
            {
                Name = "Some Test Product",
                Description = "Some description",
                Price = 3.2M,
                Quantity = 20,
                IsActive = true,    
            };
        }

        [HttpDelete]
        public string SoftUni()
        {
            return "Delete";
        }

        [HttpPost]
        public string SoftUni1()
        {
            return "Post";
        }
    }
}
