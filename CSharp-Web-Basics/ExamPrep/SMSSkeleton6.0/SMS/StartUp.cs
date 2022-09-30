namespace SMS
{
    using BasicWebServer.Server;
    using BasicWebServer.Server.Routing;
    using System.Threading.Tasks;

    public class StartUp
    {
        public static async Task Main()
        {
            var server = new HttpServer(routes => routes
               .MapControllers()
               .MapStaticFiles());

            //server.ServiceCollection
            //    .Add<IUserService, UserService>();

            await server.Start();
        }
    }
}