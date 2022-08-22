using BasicWebServer.Server.HTTP;

namespace BasicWebServer.Server.Responses
{
    public class BadRequestResponce : Response
    {
        public BadRequestResponce() : base(StatusCode.BadRequest)
        {
        }
    }
}
