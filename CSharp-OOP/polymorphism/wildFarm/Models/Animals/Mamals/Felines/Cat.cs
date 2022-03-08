using System;
namespace wildFarm.Models.Animals.Mamals
{
    public class Cat:Feline
    {
        public Cat(string name, double weight, string livingRegion, string bread) : base(name, weight, livingRegion, bread)
        {
        }

        public override string ProduseSound()
        {
            return "Meow";
        }
    }
}
