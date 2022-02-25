using System;
using System.Collections.Generic;
using System.Linq;

namespace oldestFamilyMember//DefiningClasses
{
    public class Person
    {
        public string Name { get; set; }
        public int Age { get; set; }

        public Person(string name, int age)
        {
            Name = name;
            Age = age;
        }

        public override string ToString()
        {
            return $"{Name} {Age}";
        }
    }

    public class Family
    {
        public List<Person> Peoples { get; set; }

        //public Family()
        //{
        //    Peoples = new List<Person>();
        //}
        public Family(List<Person> peoples)
        {
            Peoples = peoples;
        }

        public void AddMember(Person person)
        {
            Peoples.Add(person);
        }

        public Person GetOldestMember()
        {
            Person oldest = Peoples.OrderByDescending(x => x.Age).FirstOrDefault();
            return oldest;
        }
    }

    public class StartUp//Program
    {
        static void Main(string[] args)
        {
            Family family = new Family(new List<Person>());


            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine().Split(' ');

                Person person = new Person(input[0], int.Parse(input[1]));

                family.AddMember(person);
            }

            Console.WriteLine(family.GetOldestMember().ToString()); 
        }
    }

    
}
