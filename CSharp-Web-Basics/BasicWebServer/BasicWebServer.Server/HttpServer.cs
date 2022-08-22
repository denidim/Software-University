using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace BasicWebServer.Server
{
    public class HttpServer
    {
        private readonly IPAddress ipAddress;
        private  readonly int port;
        private readonly TcpListener serverListener;

        public HttpServer(string ipAddress, int port)
        {
            this.ipAddress = IPAddress.Parse(ipAddress);
            this.port = port;
            this.serverListener = new TcpListener(this.ipAddress, port);
        }

        public void Start()
        {
            this.serverListener.Start();
            Console.WriteLine($"Server started on port {port}");
            Console.WriteLine($"Listening for requests...");

            while (true)
            {
                var connection = serverListener.AcceptTcpClient();

                var networkStream = connection.GetStream();

                var requestText = this.ReadRequest(networkStream);

                Console.WriteLine(requestText);

                WriteResponce(networkStream, "Hello from Server!");

                connection.Close();
            }
        }

        private void WriteResponce(NetworkStream networkStream, string message)
        {
            var contentLength = Encoding.UTF8.GetByteCount(message);

            var responce = $@"HTTP/1.1 200 OK
Content-Type: text/plain; charset=UTF-8
Content-Length: {contentLength}

{message}";

            var responseBytes = Encoding.UTF8.GetBytes(responce);

            networkStream.Write(responseBytes);
        }

        private string ReadRequest(NetworkStream networkStream)
        {
            var bufferLength = 1024;
            var buffer = new byte[bufferLength];

            var totalBytes = 0;

            var requesrBuilder = new StringBuilder();

            do
            {
                var bytesRead = networkStream.Read(buffer, 0, bufferLength);

                totalBytes += bytesRead;

                if (totalBytes > 10 * 1024)
                {
                    throw new InvalidOleVariantTypeException("Request is too large.");
                }

                requesrBuilder.Append(Encoding.UTF8.GetString(buffer, 0, bytesRead));
            }
            //My not work correctly over the internet
            while (networkStream.DataAvailable);

            return requesrBuilder.ToString();
        }
    }
}
