using System;
namespace wildFarm.Models.Animals.Mamals
{
    public class Tiger : Feline
    {
        public Tiger(string name, double weight, string livingRegion, string bread) : base(name, weight, livingRegion, bread)
        {
        }

        public override string ProduseSound()
        {
            return "ROAR!!!";
        }
    }
}
