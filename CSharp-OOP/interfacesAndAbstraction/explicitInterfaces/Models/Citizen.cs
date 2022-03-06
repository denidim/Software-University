using System;
using explicitInterfaces.Interfaces;

namespace explicitInterfaces.Models
{
    public class Citizen : IPerson, IResident
    {
        public Citizen(string name, string country, int age)
        {
            Name = name;
            Country = country;
            Age = age;
        }

        public string Name { get; set; }
        public int Age { get; set; }
        public string Country { get; set; }


        public string name => Name;

        public int age => Age;

        public string country => Country;

        string IResident.GetName()
        {
            return $"Mr/Ms/Mrs {this.Name}";
        }

        string IPerson.GetName()
        {
            return this.Name;
        }
    }
}
