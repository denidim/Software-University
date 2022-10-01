using BasicWebServer.Server.Attributes;
using BasicWebServer.Server.Controllers;
using BasicWebServer.Server.HTTP;
using SMS.Contracts;
using SMS.Data.Models;

namespace SMS.Controllers
{
    public class CartsController : Controller
    {
        private readonly ICartService cartService;


        public CartsController(Request request, ICartService _cartService)
            : base(request)
        {
            cartService = _cartService;
        }

        [Authorize]
        public Response AddProduct(string productId)
        {
            var product = cartService.AddProduct(productId, User.Id);

            return View(new
            {
                product = product,
                IsAuthenticated = true
            }, "/Carts/Details");
        }

        [Authorize]
        public Response Buy()
        {
            cartService.BuyProduct(User.Id);

            return Redirect("/");
        }

        [Authorize]
        public Response Details()
        {
            var products = cartService.GetProducts(User.Id);

            return View(new
            {
                products = products,
                IsAuthenticated = true
            });

        }
    }
}
