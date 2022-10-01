using BasicWebServer.Server.Attributes;
using BasicWebServer.Server.Controllers;
using BasicWebServer.Server.HTTP;
using SMS.Contracts;
using SMS.Models;

namespace SMS.Controllers
{
    public class ProductsController : Controller
    {
        private readonly IProductService productService;

        public ProductsController(Request request, IProductService product) 
            : base(request)
        {
            productService = product;
        }

        [Authorize]
        public Response Create()
        {

            return View(new { IsAuthenticated = true});
        }

        [HttpPost]
        [Authorize]
        public Response Create(CreateViewModel model)
        {
            var(created, error) = productService.Create(model);

            if (!created)
            {
                return View(new { ErrorMessage = error }, "/Error");
            }

            return Redirect("/");
        }
    }
}
