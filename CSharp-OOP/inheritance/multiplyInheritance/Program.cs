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

public class Puppy : Dog
{
    public void Weep()
    {
        Console.WriteLine("weeping");
    }
}

namespace Farm//multiplyInheritance
{
    public class StartUp//Program
    {
        static void Main(string[] args)
        {
            Puppy puppy = new Puppy();

            puppy.Eat();
            puppy.Bark();
            puppy.Weep();
        }
    }
}
