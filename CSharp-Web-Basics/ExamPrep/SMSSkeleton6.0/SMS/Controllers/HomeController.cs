using BasicWebServer.Server.Controllers;
using BasicWebServer.Server.HTTP;
using SMS.Contracts;
using SMS.Data.Models;
using SMS.Models;
using System.Collections.Generic;
using System.Threading;

namespace SMS.Controllers
{
    public class HomeController : Controller
    {
        private readonly IUserService userService;
        private readonly IProductService productService;


        public HomeController(Request request, IUserService _userService,IProductService _product) 
            : base(request)
        {
            userService = _userService;
            productService = _product;
        }

        public Response Index()
        {
            if (User.IsAuthenticated)
            {
                string username = userService.GetUsername(User.Id);

                var model = new
                {
                    Username = username,
                    IsAuthenticated = true,
                    Product = productService.GetProducts()
                };

                return View(model, "/Home/IndexLoggedIn");


            }

            return this.View(new { IsAuthenticated = false });
        }
    }
}