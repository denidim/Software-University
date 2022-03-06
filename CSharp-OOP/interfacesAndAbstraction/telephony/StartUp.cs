using System;
using Telephony.Models;

namespace Telephony
{
    public class StartUp
    {
        static void Main(string[] args)
        {

            Smarthphone smartphone = new Smarthphone();
            StationaryPhone stationary = new StationaryPhone();

            string[] numers = Console.ReadLine()
                .Split(' ',StringSplitOptions.RemoveEmptyEntries);

            string[] urls = Console.ReadLine()
                .Split(' ',StringSplitOptions.RemoveEmptyEntries);

            for (int i = 0; i < numers.Length; i++)
            {
                try
                {
                    if (numers[i].Length == 10)
                    {
                        Console.WriteLine(smartphone.Call(numers[i]));
                    }
                    else if (numers[i].Length == 7)
                    {
                        Console.WriteLine(stationary.Call(numers[i]));

                    }
                }
                catch (InvalidPhoneNumberException ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            for (int i = 0; i < urls.Length; i++)
            {
                try
                {
                    Console.WriteLine(smartphone.Browse(urls[i]));
                }
                catch (InvalidUrlNameException ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }
    }
}
