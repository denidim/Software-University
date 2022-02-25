using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Diagnostics.SymbolStore;

namespace comparingObjects
{
    class Person : IComparable<Person>
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public string Town { get; set; }

        public Person(string name,int age,string town)
        {
            Name = name;
            Age = age;
            Town = town;
        }

        public int CompareTo(Person other)
        {
            int name = this.Name.CompareTo(other.Name);
            int Age = this.Age.CompareTo(other.Age);
            int Town = this.Town.CompareTo(other.Town);
            return name + Age + Town;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var people = new List<Person>();
            string input;
            while ((input = Console.ReadLine()) != "END")
            {
                string[] tockens = input.Split();

                var person = new Person(tockens[0],int.Parse(tockens[1]),tockens[2]);
                people.Add(person);
            }

            int position = int.Parse(Console.ReadLine());

            int totalPeole = people.Count;
            int equal = 0;
            int notEqual = 0;

            foreach (var item in people)
            {
                if (people[position-1].CompareTo(item)==0)
                {
                    equal++;
                }
                else
                {
                    notEqual++;
                }
            }
            if (equal <= 1 )
            {
                Console.WriteLine("No matches");
            }
            else
            {
                Console.WriteLine($"{equal} {notEqual} {totalPeole}");
            }

        }
    }
}
