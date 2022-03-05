using System;
using System.Collections.Generic;

namespace PersonsInfo//team
{
    public class Team
    {
        private string name;
        private readonly List<Person> firstTeam;
        private readonly List<Person> reserveTeam;

        public Team(string name)
        {
            this.Name = name;
            this.firstTeam = new List<Person>();
            this.reserveTeam = new List<Person>();
        }

        public IReadOnlyCollection<Person> ReserveTeam => reserveTeam.AsReadOnly();

        public IReadOnlyCollection<Person> FirstTeam => firstTeam.AsReadOnly();

        public string Name { get => name; private set => name = value; }

        public void AddPlayer(Person person)
        {
            if (person.Age < 40)
            {
                this.firstTeam.Add(person);
            }
            else
            {
                this.reserveTeam.Add(person);
            }
        }
    }

    public class Person
    {
        private string firtsName;
        private string lastName;
        private int age;
        private double salary;

        public Person(string firtsName, string lastName, int age, double salary)
        {
            this.FirtsName = firtsName;
            this.LastName = lastName;
            this.Age = age;
            this.Salary = salary;
        }

        public string FirtsName { get => firtsName; private set => firtsName = value; }
        public string LastName { get => lastName; private set => lastName = value; }
        public int Age { get => age; private set => age = value; }
        public double Salary { get => salary; private set => salary = value; }
    }

    public class StartUp
    {
        public static void Main()
        {
            var numberOfPeople = int.Parse(Console.ReadLine());
            var team = new Team("Name");

            while (numberOfPeople > 0)
            {
                var input = Console.ReadLine().Split();

                var person = new Person(input[0], input[1], int.Parse(input[2]), double.Parse(input[3]));
                team.AddPlayer(person);

                numberOfPeople--;
            }

            Console.WriteLine($"First team have {team.FirstTeam.Count} players");
            Console.WriteLine($"Reserve team have {team.ReserveTeam.Count} players");
        }
    }
}