using System;
using System.Collections.Generic;
using System.Linq;

namespace thePartyReservationFilterModule
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> names = Console.ReadLine().Split().ToList();
            var dictionary = new Dictionary<string, Predicate<string>>();
            string command = Console.ReadLine();
            while (command != "Print")
            {
                string[] tockens = command.Split(';');
                string action = tockens[0];
                string predticateAction = tockens[1];
                string value = tockens[2];

                string key = predticateAction + " " + value;

                if (action== "Add filter")
                {
                    Predicate<string> predicate = GetPredicate(predticateAction, value);
                    dictionary.Add(key, predicate);
                }
                else
                {
                    dictionary.Remove(key);
                }

                command = Console.ReadLine();
            }

            foreach (var (key,predicate) in dictionary)
            {
                names.RemoveAll(predicate);
            }

            Console.WriteLine(string.Join(" ",names));

        }
        private static Predicate<string> GetPredicate(string tockens, string parm)
        {
            if (tockens == "Starts with")
            {
                return x => x.StartsWith(parm);
            }
            if (tockens == "Ends with")
            {
                return x => x.EndsWith(parm);
            }
            if (tockens == "Contains")
            {
                return x => x.Contains(parm);
            }

            int length = int.Parse(parm);

            return x => x.Length == length;
        }
    }
}
