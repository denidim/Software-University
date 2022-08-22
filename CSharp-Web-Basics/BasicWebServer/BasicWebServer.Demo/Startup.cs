using System;
using BasicWebServer.Server;

namespace BasicWebServer.Demo
{
    internal class Startup
    {
        static void Main(string[] args)
        {
            var server = new HttpServer("127.0.0.1", 8080);
            server.Start();
        }
    }
}
