using System;
namespace prototype
{
    public class Sandwich : SandwichPrototype
    {
        public Sandwich(string bread, string meat, string cheese, string veggies)
        {
            this.bread = bread;
            this.meat = meat;
            this.cheese = cheese;
            this.veggies = veggies;
        }
        private string bread;
        private string meat;
        private string cheese;
        public string veggies;


        public override SandwichPrototype ShallowCopy()
        {
            string ingredientList = GetIngredientList();
            Console.WriteLine($"Shallow Copy sandwich with ingredients: {ingredientList}");
            return MemberwiseClone() as Sandwich;
        }

        
        public override SandwichPrototype DeepCopy()
        {
            string ingredientList = GetIngredientList();
            Console.WriteLine($"Deep Copy sandwich with ingredients: {ingredientList}");

            Sandwich sandwich = new Sandwich(
                bread = new(this.bread),
                meat = new(this.meat),
                cheese = new(this.cheese),
                veggies = new(this.veggies));

            return sandwich;
        }

        private string GetIngredientList()
        {
            return $"{this.bread}, {this.meat}, {this.cheese}, {this.veggies}";
        }
    }
}