using System;
using System.Linq;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using BasicWebServer.Demo.Controllers;
using BasicWebServer.Server;
using BasicWebServer.Server.Controller;
using BasicWebServer.Server.HTTP;
using BasicWebServer.Server.Responses;

namespace BasicWebServer.Demo
{
    public class Startup
    {

        private const string LoginForm = @"<form action='/Login' method='POST'>
            Username: <input type='text' name='Username'/>
            Password: <input type='text' name='Password'/>
            <input type='submit' value ='Log In' />
        </form>";


        private const string Username = "user";
        private const string Password = "pass";

        public static async Task Main()
            => await new HttpServer(routes => routes
                .MapGet<HomeController>("/", c => c.Index())
                .MapGet<HomeController>("/Redirect", c => c.Redirect())
                .MapGet<HomeController>("/HTML", c => c.Html())
                .MapPost<HomeController>("/HTML", c => c.HtmlFormPost())
                .MapGet<HomeController>("/Content", c => c.Content())
                .MapPost<HomeController>("/Content", c => c.DownloadContent())
                .MapGet<HomeController>("/Cookies", c => c.Cookies())
                .MapGet<HomeController>("/Session", c => c.Session())).Start();
                //.MapGet("/Login", new HtmlResponse(Startup.LoginForm))
                //.MapPost("/Login", new HtmlResponse("", Startup.LoginAction))
                //.MapGet("/Logout", new HtmlResponse("",Startup.LogoutAction))
                //.MapGet("/UserProfile", new HtmlResponse("",Startup.GetUserDataAction)));

        private static void GetUserDataAction(Request request, Response response)
        {
            if (request.Session.ContainsKey(Session.SessionUserKey))
            {
                response.Body = "";
                response.Body += $"<h3>Currently logged-in user is with username '{Username}'</h3>";
            }
            else
            {
                response.Body = "";
                response.Body += $"<h3>You should first log in - <a href='/Login'>Login</a> </h3>";
            }
        }

        private static void LogoutAction(Request request, Response response)
        {
            request.Session.Clear();

            response.Body = "";
            response.Body += "<h3>Logged out successfully!</h3>";

        }

        private static void LoginAction(Request request, Response response)
        {
            request.Session.Clear();

            var bodyText = "";

            var usernameMatches = request.Form["Username"] == Startup.Username;
            var passwordMatches = request.Form["Password"] == Startup.Password;

            if (usernameMatches && passwordMatches)
            {
                request.Session[Session.SessionUserKey] = "MyUserId";
                response.Cookies.Add(Session.SessionCookieName, request.Session.Id);

                bodyText = "<h3>Logged successfully!</h3>";
            }
            else
            {
                bodyText = Startup.LoginForm;
            }

            response.Body = "";
            response.Body += bodyText;
        }
       
    }
}
