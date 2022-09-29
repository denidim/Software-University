using BasicWebServer.Server.Controllers;
using BasicWebServer.Server.HTTP;

namespace SharedTrip.Controllers
{
    public class TripsController : Controller
    {
        public TripsController(Request request) 
            : base(request)
        {
        }
    }
}
