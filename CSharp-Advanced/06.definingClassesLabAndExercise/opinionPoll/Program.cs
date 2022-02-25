using System;
using System.Collections.Generic;
using System.Linq;

namespace DefiningClasses//opinionPoll
{
    public class Person
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public List<Person> People{ get; set; }

        public Person(string name, int age)
        {
            Name = name;
            Age = age;
        }
        public Person()
        {
            People = new List<Person>();
        }

        public override string ToString(object stringbuilder)
        {
            return $"{Name} - {Age}";
        }
    }

    public class StartUp//Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            Person peopleList = new Person();
            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine().Split(' ');

                Person person = new Person(input[0], int.Parse(input[1]));
                peopleList.People.Add(person);
            }

            Func<Person, bool> filter = p => p.Age > 30;

            foreach (var item in peopleList.People.Where(filter).OrderBy(x => x.Name))
            {
                Console.WriteLine(item.ToString());
            }
        }
    }
}
