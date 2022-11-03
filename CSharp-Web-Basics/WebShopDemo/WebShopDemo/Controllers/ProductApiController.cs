using Microsoft.AspNetCore.Mvc;

namespace WebShopDemo.Controllers
{
    public class ProductApiController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
