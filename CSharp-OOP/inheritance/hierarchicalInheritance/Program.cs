using System;

public class Animal
{
    public void Eat()
    {
        Console.WriteLine("eating");
    }
}

public class Dog : Animal
{
    public void Bark()
    {
        Console.WriteLine("barking");
    }
}

public class Cat : Animal
{
    public void Meow()
    {
        Console.WriteLine("meowing");
    }
}

namespace Farm//hierarchicalInheritance
{
    public class StartUp//Program
    {
        static void Main(string[] args)
        {
            Dog dog = new Dog();
            dog.Eat();
            dog.Bark();

            Cat cat = new Cat();
            cat.Eat();
            cat.Meow();
        }
    }
}
