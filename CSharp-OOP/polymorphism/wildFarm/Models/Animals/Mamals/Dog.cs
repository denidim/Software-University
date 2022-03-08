using System;
namespace wildFarm.Models.Animals.Mamals
{
    public class Dog : Mammal
    {
        public Dog(string name, double weight, string linigRegion) : base(name, weight)
        {
            LivingRegion = linigRegion;
        }

        public override string ProduseSound()
        {
            return "Woof!";
        }
    }
}
