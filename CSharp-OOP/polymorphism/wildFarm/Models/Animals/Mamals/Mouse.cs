using System;
namespace wildFarm.Models.Animals.Mamals
{
    public class Mouse : Mammal
    {
        public Mouse(string name, double weight, string linigRegion) : base(name, weight)
        {
            LivingRegion = linigRegion;
        }

        public override string ProduseSound()
        {
            return "Squeak";
        }
    }
}
