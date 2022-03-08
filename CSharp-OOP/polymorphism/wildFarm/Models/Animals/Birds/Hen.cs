using System;
namespace wildFarm.Models.Animals
{
    public class Hen:Bird
    {
        public Hen(string name, double weight, double wingSize) : base(name, weight, wingSize)
        {
        }

        public override string ProduseSound()
        {
            return "Cluck";
        }
    }
}
