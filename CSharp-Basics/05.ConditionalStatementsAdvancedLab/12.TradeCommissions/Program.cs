using System;

namespace _12.TradeCommissions
{
    class Program
    {
        static void Main(string[] args)
        {
            string city = Console.ReadLine().ToLower();
            double sales = double.Parse(Console.ReadLine());

            
            if (city == "sofia")
            {
                if (sales < 0)
                {
                    Console.WriteLine("error");
                }
                else if (0 <= sales && sales <= 500)
                {
                    Console.WriteLine("{0:f2}",(5 / 100.0) * sales);
                }
                else if (sales > 500 && sales <= 1000)
                {
                    Console.WriteLine("{0:f2}", (7 / 100.0) * sales);
                }
                else if (sales > 1000 && sales <= 10000)
                {
                    Console.WriteLine("{0:f2}", (8 / 100.0) * sales);
                }
                else if (sales > 10000)
                {
                    Console.WriteLine("{0:f2}", (12 / 100.0) * sales);
                }
            }
            else if (city == "varna")
            {
                if (sales < 0)
                {
                    Console.WriteLine("error");
                }
                else if (sales <= 500)
                {
                    Console.WriteLine("{0:f2}", (4.5 / 100.0) * sales);
                }
                else if (sales > 500 && sales <= 1000)
                {
                    Console.WriteLine("{0:f2}", (7.5 / 100.0) * sales);
                }
                else if (sales > 1000 && sales <= 10000)
                {
                    Console.WriteLine("{0:f2}", (10 / 100.0) * sales);
                }
                else if (sales > 10000)
                {
                    Console.WriteLine("{0:f2}", (13 / 100.0) * sales);
                }
                
            }
            else if (city == "plovdiv")
            {
                if (sales < 0)
                {
                    Console.WriteLine("error");
                }
                else if (sales <= 500)
                {
                    Console.WriteLine("{0:f2}", (5.5 / 100.0) * sales);
                }
                else if (sales > 500 && sales <= 1000)
                {
                    Console.WriteLine("{0:f2}", (8 / 100.0) * sales);
                }
                else if (sales > 1000 && sales <= 10000)
                {
                    Console.WriteLine("{0:f2}", (12 / 100.0) * sales);
                }
                else if (sales > 10000)
                {
                    Console.WriteLine("{0:f2}", (14.5 / 100.0) * sales);
                }
                
            }
            else
            {
                Console.WriteLine("error");
            }
        }
    }
}


