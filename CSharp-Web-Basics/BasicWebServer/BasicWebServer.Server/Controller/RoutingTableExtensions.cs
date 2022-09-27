using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BasicWebServer.Server.HTTP;
using BasicWebServer.Server.Routing;

namespace BasicWebServer.Server.Controller
{
    public static class RoutingTableExtensions
    {
        public static IRoutingTable MapGet<TController>(
            this IRoutingTable routingTable,
            string path,
            Func<TController, Response> controllerFunction)
            where TController : Controller
            => routingTable.MapGet(path, request => controllerFunction(
                CreateController<TController>(request)));

        public static IRoutingTable MapPost<TController>(
            this IRoutingTable routingTable,
            string path,
            Func<TController, Response> controllerFunction)
            where TController : Controller
            => routingTable.MapPost(path, request => controllerFunction(
                CreateController<TController>(request)));


        public static TController CreateController<TController>(Request request)
        => (TController)Activator.CreateInstance(typeof(TController), new[] {request});

    }
}
