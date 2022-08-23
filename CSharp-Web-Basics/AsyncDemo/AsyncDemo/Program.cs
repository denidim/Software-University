using System.Diagnostics;
using System.Dynamic;

namespace AsyncDemo
{
    internal class Program
    {
        private static int Count = 0;

        static void Main(string[] args)
        {
            RunDownloadAsync();
        }

        private static void RunDownloadAsync()
        {
            Stopwatch sw = Stopwatch.StartNew();
            List<Task> tasks = new List<Task>();

            for (int i = 55916; i < 55916 + 20; i++)
            {
                var task = Task.Run(() => DownloadAsync(i));
                tasks.Add(task);
            }

            Task.WaitAll(tasks.ToArray());

            Console.WriteLine(sw.Elapsed);
            Console.ReadLine();
        }

        static async Task DownloadAsync(int i)
        {
            HttpClient client = new HttpClient();
            var url = $"https://vicove.com/vic-{i}";
            var responce =  await client.GetAsync(url);
            var vic = await responce.Content.ReadAsStringAsync();
            Console.WriteLine(vic);
        }
        
        private static void StartRaceCondition()
        {
            Stopwatch sw = Stopwatch.StartNew();

            Thread thread = new Thread(() => PrintPrimeCount(1, 2_500_000));
            thread.Start();
            Thread thread2 = new Thread(() => PrintPrimeCount(2_500_001, 5_000_000));
            thread2.Start();
            Thread thread3 = new Thread(() => PrintPrimeCount(5_000_001, 7_500_000));
            thread3.Start();
            Thread thread4 = new Thread(() => PrintPrimeCount(7_500_001, 10_000_000));
            thread4.Start();

            thread.Join();
            thread2.Join();
            thread3.Join();
            thread4.Join();
            Console.WriteLine(Count);
            Console.WriteLine(sw.Elapsed);
            while (true)
            {
                var input = Console.ReadLine();
                Console.WriteLine(input.ToUpper());
            }
        }

        private static void PrintPrimeCount(int min, int max)
        {
            for (int i = min; i < max; i++)
            {
                bool isPrime = true;

                for (int j = 2; j <= Math.Sqrt(i); j++)
                {
                    if (i % j == 0)
                    {
                        isPrime = false;
                        break;
                    }
                }

                if (isPrime)
                {//if we lock here we can fix the Race Condition problem 
                    Count++;
                }
            }
            
        }

        private static async Task GetUrlPageAsync()
        {
            string url = "https://softuni.bg";

            using (HttpClient client = new HttpClient())
            {
                var result = await client.GetAsync(url);

                if (result.IsSuccessStatusCode)
                {
                    string content = await result.Content.ReadAsStringAsync();
                    Console.WriteLine(content);
                }
            }
        }

        private static void RunTaskInBackground()
        {
            long sum = 0;

            Task.Run(() =>
            {
                for (int i = 0; i < 100-000-000-000; i++)
                {
                    sum += i;
                }
            });

            while (true)
            {
                string command = Console.ReadLine();

                if (command == "show")
                {
                    Console.WriteLine(sum);
                }
                else if (command == "exit")
                {
                    return;
                }
            }
        }

        private static void RunThread()
        {
            Thread evens = new Thread(() => PrintEvenNumbers(0, 100));
            evens.Start(); //start execution of the thread
            evens.Join(); //we tell the thread where to finish
            Console.WriteLine("Thread finished work");
        }

        private static void PrintEvenNumbers(int start, int end)
        {
            for (int i = start; i <= end; i++)
            {
                if (i % 2 == 0)
                {
                    Console.WriteLine(i);
                }
            }
        }

        private static void RunTask()
        {
            PrintNumbersInRange(0, 100);

            Task task = Task.Run(() => PrintNumbersInRange(100, 200));

            Console.WriteLine("Done");

            task.Wait();//here the program stops and waits for this task to finish
        }

        private static void PrintNumbersInRange(int a, int b)
        {
            for (int i = a; i < b; i++)
            {
                Console.Write($"{i},");
            }
        }
    }
}