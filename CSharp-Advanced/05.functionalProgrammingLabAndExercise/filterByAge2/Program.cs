using System;
using System.Collections.Generic;
using System.Linq;

namespace filterByAge2
{
    class Person
    {
        public string Name;
        public int Age;
    }
    class Program
    {
        static void Main(string[] args)
        {
            List<Person> people = new List<Person>();
            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine().Split(", ");
                string name = input[0];
                int age = int.Parse(input[1]);
                Person person = new Person();
                person.Name = name;
                person.Age = age;
                people.Add(person);
            }
            string filterBy = Console.ReadLine();
            int ageToCompare = int.Parse(Console.ReadLine());
            string format = Console.ReadLine();
            
            Func<Person, bool> filter = p => true;

            if (filterBy == "younger")
            {
                filter = p => p.Age < ageToCompare;
            }
            else if (filterBy == "older")
            {
                filter = p => p.Age >= ageToCompare;
            }

            var newPeople = people.Where(filter);


            Func<Person, string> printFunc = p => p.Name + " - " + p.Age;

            if (format == "name")
            {
                printFunc = p => p.Name;
            }
            else if (format == "age")
            {
                printFunc = p => p.Age.ToString();
            }
            else
            {
                printFunc = p => p.Name + " - " + p.Age;
            }

            var personAsString = newPeople.Select(printFunc);

            foreach (var item in personAsString)
            {
                Console.WriteLine(item);
            }
        }
    }
}
