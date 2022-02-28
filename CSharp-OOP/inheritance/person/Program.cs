using System;
using System.Text;

namespace person
{
    public class Person
    {
        private string _name;
        private int _age;

        public string Name { get => _name; set => _name = value; }

        public virtual int Age
        {
            get => _age;
            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("Age out of range");
                }
                else
                {
                    _age = value;
                }
            }
        }
        public Person(string name,int age)
        {
            Name = name;
            Age = age;
        }
        public override string ToString()
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append($"Name: {Name}, Age: {Age}");
            return stringBuilder.ToString();
        }
    }
    public class Child : Person
    {
        public override int Age
        {
            get => base.Age;
            set
            {
                if (value > 15)
                {
                    throw new ArgumentOutOfRangeException();
                }
                else
                {
                    base.Age = value;
                }
            }
        }

        public Child(string name,int age) : base(name,age)
        {

        }
    }

    class Program
    { 
        static void Main(string[] args)
        {
            string name = Console.ReadLine();
            int age = int.Parse(Console.ReadLine());

            Person person;
            if (age <= 15)
            {
                person = new Child(name,age);
            }
            else
            {
                person = new Person(name, age);
            }

            Console.WriteLine(person);
        }
    }
}
