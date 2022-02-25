using System;
using System.Collections.Generic;
using System.Linq;

namespace predicateParty
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> names = Console.ReadLine().Split(' ').ToList();

            string command;

            while ((command=Console.ReadLine())!="Party!")
            {
                string[] tockens = command.Split(' ');

                Predicate<string> predicate = GetPredicate(tockens[1],tockens[2]);

                if (tockens[0] == "Remove")
                {
                    names.RemoveAll(predicate);
                }

                else if (tockens[0] == "Double")
                {
                    List<string> doubleNames = names.FindAll(predicate);

                    if (doubleNames.Any())
                    {
                        int index = names.FindIndex(predicate);
                        names.InsertRange(index, doubleNames);
                    }
                }
            }
            if (names.Count != 0)
            {
                Console.WriteLine($"{ string.Join(", ", names)} are going to the party!");
            }
            else
            {
                Console.WriteLine("Nobody is going to the party!");
            }
        }

        private static Predicate<string> GetPredicate(string tockens,string parm)
        {
            if (tockens == "StartsWith")
            {
                return x => x.StartsWith(parm);
            }
            if (tockens == "EndsWith")
            {
                return x => x.EndsWith(parm);
            }
            int length = int.Parse(parm);

            return x => x.Length == length;
        }
    }
}
