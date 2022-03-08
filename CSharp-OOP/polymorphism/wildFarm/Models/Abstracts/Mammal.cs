namespace wildFarm.Models
{

    public abstract class Mammal : Animal
    {
        public string LivingRegion { get; set; }
        protected Mammal(string name, double weight) : base(name, weight)
        {
        }
        public override string ToString()
        {
            //Mice and Dogs - "{AnimalType} [{AnimalName}, {AnimalWeight}, {AnimalLivingRegion}, {FoodEaten}]"

           return $"{this.GetType().Name} [{Name}, {Weight}, {LivingRegion}, {FoodEaten}]";
        }
    }
}
