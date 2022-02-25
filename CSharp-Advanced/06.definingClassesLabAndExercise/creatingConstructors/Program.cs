using System;
using creatingConstructors;
namespace creatingConstructors//DefiningClasses//
{
    public class Program//StartUp//
    {
        static void Main(string[] args)
        {

            Person person1 = new Person();
            {
                person1.Name = "Peter";
                person1.Age = 20;
            }
            Person person2 = new Person();
            {
                person2.Name = "George";
                person2.Age = 18;
            }
            Person person3 = new Person();
            {
                person3.Name = "Jose";
                person3.Age = 43;
            }
        }
    }
    public class Person
    {
        public string Name { get; set; }
        public int Age { get; set; }

        public Person()
        {
            Name = "No name";
            Age = 1;
        }
        public Person(int age) : this()
        {
            Age = age;
        }
        public Person(string name, int age)
        {
            Name = name;
            Age = age;
        }
    }

}
