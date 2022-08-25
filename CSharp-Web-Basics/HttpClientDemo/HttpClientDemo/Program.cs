using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Sockets;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace HttpClientDemo
{
    internal class Program
    {
        static Dictionary<string, int> SessionStorage = new Dictionary<string, int>();

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

            var match = Regex.Match(request, "sid=[^\n]*\r\n");

            var sid = Guid.NewGuid().ToString();
            if (match.Success)
            {
                sid = match.Value.Substring(4);
            }

            if (!SessionStorage.ContainsKey(sid))
            {
                SessionStorage.Add(sid,0);
            }

            SessionStorage[sid]++;

            Console.WriteLine(sid);

            string form = $"<form action=/tweet method=post>;" +
                          $"<input name=username /><input name=password />;" +
                          $"<input type=submit /></form>";

            string html = $"<h1>Hello from Demo Server {DateTime.Now} for the {SessionStorage[sid]} time</h1>{form}";

            var byteLength = Encoding.UTF8.GetByteCount(html);

            string response = "HTTP/1.1 200 OK" + NewLine +
                              "Server: Demo Server" + NewLine +
                              "Content-Type: text/html; charset=utf-8" + NewLine +
                              "X-Server-Version: 1.0" + NewLine +               //Nax-Ade = 24*3 * 60 * 60 = 3days
                              $"Set-Cookie: sid={sid}; HttpOnly; Expires="+ DateTime.UtcNow.AddHours(1).ToString("R") + NewLine +
                              "Content-Length: " + byteLength + NewLine +
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
