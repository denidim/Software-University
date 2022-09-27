using BasicWebServer.Server.HTTP;
using System;

namespace BasicWebServer.Server.Responses
{
    public class TextResponse : ContentResponse
    {
        public TextResponse(string text)
            : base(text, ContentType.PlainText) 
        {
        }
    }
}
