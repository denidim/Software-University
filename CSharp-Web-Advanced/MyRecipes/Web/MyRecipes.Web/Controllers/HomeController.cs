namespace MyRecipes.Web.Controllers
{
    using System.Diagnostics;

    using Microsoft.AspNetCore.Mvc;
    using MyRecipes.Services.Data;
    using MyRecipes.Web.ViewModels;

    // 1. ApplicationDbContext
    // 2. Repositories
    // 3. Serices
    public class HomeController : BaseController
    {
        private readonly IGetCountsSerice getCountsSerice;

        public HomeController(IGetCountsSerice getCountsSerice)
        {
            this.getCountsSerice = getCountsSerice;
        }

        public IActionResult Index()
        {
            var viewModel = this.getCountsSerice.GetCounts();

            return this.View(viewModel);
        }

        public IActionResult Privacy()
        {
            return this.View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return this.View(
                new ErrorViewModel { RequestId = Activity.Current?.Id ?? this.HttpContext.TraceIdentifier });
        }
    }
}
