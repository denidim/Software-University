using System;

namespace PersonInfo//defineAnInterfaceIperson
{
    //Define an interface IPerson with properties for Name and Age. Define a class Citizen that implements IPerson and has a constructor which takes a string name and an int age.

    public interface IPerson
    {
        string Name { get; }
        int Age { get; }

    }
    public class Citizen : IPerson
    {
        public string Name { get; private set; }

        public int Age { get; private set; }

        public Citizen(string name,int age)
        {
            Name = name;
            Age = age;
        }

    }

    public class StartUp
    {
        static void Main(string[] args)
        {
            string name = Console.ReadLine();
            int age = int.Parse(Console.ReadLine());
            IPerson person = new Citizen(name, age);
            Console.WriteLine(person.Name);
            Console.WriteLine(person.Age);
        }
    }
}
