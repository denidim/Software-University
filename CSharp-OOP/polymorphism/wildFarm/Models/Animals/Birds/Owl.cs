using System;
namespace wildFarm.Models.Animals
{
    public class Owl : Bird
    {
        public Owl(string name, double weight, double wingSize) : base(name, weight, wingSize)
        {
        }

        public override string ProduseSound()
        {
            return "Hoot Hoot";
        }
    }
}
