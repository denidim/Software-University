using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicWebServer.Server.HTTP
{
    public enum StatusCode
    {
        OK = 200,
        Found = 302,
        BadRequest = 400,
        Unauthorized = 401,
        NotFound = 404
    }
}
