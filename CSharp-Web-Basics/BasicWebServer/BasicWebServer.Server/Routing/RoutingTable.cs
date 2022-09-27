using BasicWebServer.Server.Common;
using BasicWebServer.Server.HTTP;
using BasicWebServer.Server.Responses;
using System;
using System.Collections.Generic;

namespace BasicWebServer.Server.Routing
{
    public class RoutingTable : IRoutingTable
    {
        private readonly Dictionary<Method,Dictionary<string,Func<Request,Response>>> routes;

        public RoutingTable() => this.routes = new()
        {
                [Method.Get] = new(StringComparer.InvariantCultureIgnoreCase),
                [Method.Post] = new(StringComparer.InvariantCultureIgnoreCase),
                [Method.Put] = new(StringComparer.InvariantCultureIgnoreCase),
                [Method.Delete] = new(StringComparer.InvariantCultureIgnoreCase),
        };


        public IRoutingTable Map(Method method, string path, Func<Request, Response> responseFunction)
        {
            Guard.AgainstNull(path,nameof(path));
            Guard.AgainstNull(responseFunction, nameof(responseFunction));

            this.routes[method][path] = responseFunction;

            return this;
        }

        public IRoutingTable MapGet(string path, Func<Request, Response> responseFunction) =>
            Map(Method.Get, path, responseFunction);


        public IRoutingTable MapPost(string path, Func<Request, Response> responseFunction) =>
            Map(Method.Post, path, responseFunction);

        public Response MatchRequest(Request request)
        {
            var requestMethod = request.Method;
            var requestUrl = request.Url;

            if (!this.routes.ContainsKey(requestMethod)
                || !this.routes[requestMethod].ContainsKey(requestUrl))
            {
                return new NotFoundResponse();
            }

            var responseFunction = this.routes[requestMethod][requestUrl];

            return responseFunction(request);
        }
    }
}
