using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BasicWebServer.Server.Controller;
using BasicWebServer.Server.HTTP;

namespace BasicWebServer.Demo.Controllers
{
    public class UserController : Controller
    {
        private const string LoginForm = @"<form action='/Login' method='POST'>
            Username: <input type='text' name='Username'/>
            Password: <input type='text' name='Password'/>
            <input type='submit' value ='Log In' />
        </form>";

        public UserController(Request request) : base(request)
        {
        }

        public Response Login() => Html(UserController.LoginForm);
    }
}
