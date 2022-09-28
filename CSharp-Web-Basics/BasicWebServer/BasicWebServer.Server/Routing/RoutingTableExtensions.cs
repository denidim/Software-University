using System;
using System.Reflection;
using BasicWebServer.Server.HTTP;

namespace BasicWebServer.Server.Routing
{
    public static class RoutingTableExtensions
    {
        public static IRoutingTable MapGet<TController>(
            this IRoutingTable routingTable,
            string path,
            Func<TController, Response> controllerFunction)
            where TController : Controller.Controller
            => routingTable.MapGet(path, request => controllerFunction(
                CreateController<TController>(request)));

        public static IRoutingTable MapPost<TController>(
            this IRoutingTable routingTable,
            string path,
            Func<TController, Response> controllerFunction)
            where TController : Controller.Controller
            => routingTable.MapPost(path, request => controllerFunction(
                CreateController<TController>(request)));


        public static TController CreateController<TController>(Request request)
        => (TController)Activator.CreateInstance(typeof(TController), new[] { request });

        private static Controller.Controller CreateController(Type controllerType, Request request)
        {
            var controller = (Controller.Controller)Request.ServiceCollection.CreateInstance(controllerType);

            controllerType
                .GetProperty("Request", BindingFlags.Instance | BindingFlags.NonPublic)
                .SetValue(controller, request);

            return controller;
        }

    }
}
