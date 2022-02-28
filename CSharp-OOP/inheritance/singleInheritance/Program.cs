using System;
using singleInheritance;

namespace Farm//singleInheritance
{
    public class StartUp//Program
    {
        static void Main(string[] args)
        {
            Dog dog = new Dog();

            dog.Eat();
            dog.Bark();
            
        }
    }
}
