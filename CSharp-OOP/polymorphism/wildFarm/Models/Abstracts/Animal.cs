using wildFarm.Models.Interfaces;

namespace wildFarm.Models
{
    public abstract class Animal : IAnimal
    {
        protected Animal(string name, double weight)
        {
            Name = name;
            Weight = weight;
        }

        public string Name { get; set; }

        public double Weight { get; set; }

        public int FoodEaten { get; set; }



        public abstract string ProduseSound();
    }
}
