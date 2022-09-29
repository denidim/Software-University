using BasicWebServer.Server.Controllers;
using BasicWebServer.Server.HTTP;

namespace SharedTrip.Controllers
{
    public class TripController : Controller
    {
        public TripController(Request request) : base(request)
        {
        }
    }
}
