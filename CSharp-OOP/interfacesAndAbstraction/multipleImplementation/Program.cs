using System;

namespace PersonInfo//multipleImplementation
{
    //interface IIdentifiable with a string property Id and an interface IBirthable with a string property Birthdate and implement them in the Citizen class. Rewrite the Citizen constructor to accept the new parameters.

    public interface IIdentifiable
    {
        string Id { get; }
    }

    public interface IBirthable
    {
        string Birthdate { get; }
    }

    public interface IPerson
    {
        string Name { get; }
        int Age { get; }

    }

    public class Citizen : IPerson,IIdentifiable,IBirthable
    {
        public string Name { get; private set; }

        public int Age { get; private set; }

        public string Id { get; private set; }

        public string Birthdate { get; private set; }

        public Citizen(string name, int age,string id,string birthdate)
        {
            Name = name;
            Age = age;
            Id = id;
            Birthdate = birthdate;
        }
    }


    public class StartUp
    {
        static void Main(string[] args)
        {
            string name = Console.ReadLine();
            int age = int.Parse(Console.ReadLine());
            string id = Console.ReadLine();
            string birthdate = Console.ReadLine();
            IIdentifiable identifiable = new Citizen(name, age, id, birthdate);
            IBirthable birthable = new Citizen(name, age, id, birthdate);
            Console.WriteLine(identifiable.Id);
            Console.WriteLine(birthable.Birthdate);
        }
    }
}
