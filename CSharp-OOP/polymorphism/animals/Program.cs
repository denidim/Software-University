using System;

namespace Animals
{

    public class Animal
    {
        private string name;
        private string favoriteFood;

        public Animal(string name, string favoriteFood)
        {
            this.name = name;
            this.favoriteFood = favoriteFood;
        }

        public virtual string ExplainSelf()
        {
            return $"I am {this.name} and my fovourite food is Whiskas";
        }
    }

    public class Cat : Animal
    {
        public Cat(string name, string favoriteFood) : base(name, favoriteFood)
        {
        }

        public override string ExplainSelf()
        {
            return $"{base.ExplainSelf()}\n\rMEEOW";
        }
    }

    public class Dog : Animal
    {
        public Dog(string name, string favoriteFood) : base(name, favoriteFood)
        {
        }

        public override string ExplainSelf()
        {
            return $"{base.ExplainSelf()}\n\rDJAAF";
        }
    }

    public class StartUp
    {
        static void Main(string[] args)
        {
            Animal cat = new Cat("Peter", "Whiskas");
            Animal dog = new Dog("George", "Meat");

            Console.WriteLine(cat.ExplainSelf());
            Console.WriteLine(dog.ExplainSelf());
        }
    }
}
