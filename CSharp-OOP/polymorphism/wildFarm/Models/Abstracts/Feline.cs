using System;
namespace wildFarm.Models
{
    public abstract class Feline : Mammal
    {

        protected Feline(string name, double weight, string livingRegion, string bread) : base(name, weight)
        {
            LivingRegion = livingRegion;
            Bread = bread;
        }
        
        public string Bread { get; set; }

        public override string ToString()
        {
            //Felines - "{AnimalType} [{AnimalName}, {Breed}, {AnimalWeight}, {AnimalLivingRegion}, {FoodEaten}]"

            return $"{this.GetType().Name} [{Name}, {Bread}, {Weight}, {LivingRegion}, {FoodEaten}]"; 
        }
    }
}
