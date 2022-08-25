using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace HttpClientDemo
{
    internal class Program
    {
        const string NewLine = "\r\n";

        static async Task Main(string[] args)
        {
            await DemoServer();

            //await ReadData();
        }

        static async Task DemoServer()
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            
            TcpListener tcpListener = new TcpListener(IPAddress.Loopback, 12345);//socket =  ip+port
            tcpListener.Start();

            //daemon // service
            while (true)
            {
                var client = await tcpListener.AcceptTcpClientAsync();

                await ProcessClientAsync(client);
            }
        }

        public static async Task ProcessClientAsync(TcpClient client)
        {
            await using var stream = client.GetStream();

            byte[] buffer = new byte[1024];

            var length = await stream.ReadAsync(buffer, 0, buffer.Length);

            string request = Encoding.UTF8.GetString(buffer, 0, length);

            Console.WriteLine(request);

            string form = $"<form method=post><input name=username /><input name=password /><input type=submit /></form>";

            string html = $"<h1>Hello from Demo Server {DateTime.Now}</h1>{form}";

            var byteLength = Encoding.UTF8.GetByteCount(html);

            string response = "HTTP/1.1 200 OK" + NewLine +
                              "Server: Demo Server" + NewLine +
                              "Content-Type: text/html; charset=utf-8" + NewLine +
                              "Content-Lenght: " + byteLength + NewLine +
                              NewLine +
                              html +
                              NewLine;

            byte[] responseBytes = Encoding.UTF8.GetBytes(response);

            await stream.WriteAsync(responseBytes);

            Console.WriteLine(new string('+', 70));
        }

        private static async Task ReadData()
        { 
            //act like client

            Console.OutputEncoding = System.Text.Encoding.UTF8;
            string url = "https://softuni.bg/courses/csharp-web-basics";

            HttpClient httpClient = new HttpClient();

            var responce = await httpClient.GetAsync(url);

            Console.WriteLine(responce.StatusCode);

            Console.WriteLine(string.Join(Environment.NewLine,
                responce.Headers.Select(x => x.Key + " " + x.Value.First())));

            var html = await httpClient.GetStringAsync(url);
            Console.WriteLine(html);
        }
    }
}
