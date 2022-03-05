using System;
using System.Collections.Generic;
using System.Linq;

namespace PersonsInfo//salary
{
    public class Person
    {
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public int Age { get; private set; }
        public decimal Salary { get; private set; }


        public Person(string firstName, string lastName, int age,decimal salary)
        {
            FirstName = firstName;
            LastName = lastName;
            Age = age;
            Salary = salary;
        }


        public override string ToString()
        {
            return $"{FirstName} {LastName} receives {Salary:f2} leva.";
        }

        public void IncreaseSalary(decimal parcentage)
        {
            if (Age < 30)
            {
                Salary += Salary* parcentage / 200;
            }
            else
            {
                Salary += Salary * parcentage / 100;
            }

        }
    }

    public class StartUp
    {
        public static void Main(string[] args)
        {
            var lines = int.Parse(Console.ReadLine());
            var persons = new List<Person>();
            for (int i = 0; i < lines; i++)
            {
                var cmdArgs = Console.ReadLine().Split();
                var person = new Person(cmdArgs[0],
                                        cmdArgs[1],
                                        int.Parse(cmdArgs[2]),
                                        decimal.Parse(cmdArgs[3]));

                persons.Add(person);
            }
            var parcentage = decimal.Parse(Console.ReadLine());
            persons.ForEach(p => p.IncreaseSalary(parcentage));
            persons.ForEach(p => Console.WriteLine(p.ToString()));
        }
    }
}
