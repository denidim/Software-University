using BasicWebServer.Server.Attributes;
using BasicWebServer.Server.Controllers;
using BasicWebServer.Server.HTTP;
using SharedTrip.Contracts;
using SharedTrip.Models;
using SharedTrip.Models.Users;
using SharedTrip.Services;
using System.Collections.Generic;

namespace SharedTrip.Controllers
{
    public class UsersController : Controller
    {
        private readonly IUserService _userService;

        public UsersController(Request request, IUserService userService) 
            : base(request)
        {
            _userService = userService;
        }

        public Response Login() => View();

        public Response Register() => View();

        [HttpPost]
        public Response Register(RegisterViewModel model)
        {
            var (isValid, errors) = _userService.ValidateModel(model);

            if (!isValid)
            {
                return View(errors, "/Error");
            }

            try
            {
                _userService.RegisterUser(model);
            }
            catch (System.Exception)
            {

                return View(new List<ErrorViewModel>() { new ErrorViewModel("Unexpexted Error") }, "/Error");
            }

            return Redirect("/Users/Login");
        }

    }

}
