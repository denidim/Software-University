using System;
using explicitInterfaces.Interfaces;
using explicitInterfaces.Models;

namespace explicitInterfaces
{
    class Program
    {
        static void Main(string[] args)
        {
            Citizen citizen;
            string command;
            while ((command = Console.ReadLine()) != "End")
            {
                string[] tokens = command.Split(' ',StringSplitOptions.RemoveEmptyEntries);
                citizen = new Citizen(tokens[0], tokens[1], int.Parse(tokens[2]));
                Console.WriteLine(((IPerson)citizen).GetName());
                Console.WriteLine(((IResident)citizen).GetName());
            }
        }
    }
}
