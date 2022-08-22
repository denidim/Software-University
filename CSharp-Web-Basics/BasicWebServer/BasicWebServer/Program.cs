using System;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace BasicWebServer
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var ipAddress = IPAddress.Parse("127.0.0.1");
            var port = 8080;

            var serverListener = new TcpListener(ipAddress,port);
            serverListener.Start();

            Console.WriteLine($"Server started on port {port}");
            Console.WriteLine($"Listening for requests...");

            while (true)
            {
                var conncetion = serverListener.AcceptTcpClient();

                var networkStream = conncetion.GetStream();

                var content = "Hello from the Server!";
                var contentLength = Encoding.UTF8.GetByteCount(content);

                var responce = $@"HTTP/1.1 200 OK
Content-Type: text/plain; charset=UTF-8
Content-Length: {contentLength}

{content}";

                var responseBytes = Encoding.UTF8.GetBytes(responce);

                networkStream.Write(responseBytes);

                conncetion.Close();
            }

        }
    }
}
