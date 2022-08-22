using BasicWebServer.Server.HTTP;
using System;

namespace BasicWebServer.Server.Responses
{
    public class TextResponse : ContentResponse
    {
        public TextResponse(string text,
            Action<Request,Response> preRenderAction = null)
            : base(text, ContentType.PlainText, preRenderAction) 
        {
        }
    }
}
