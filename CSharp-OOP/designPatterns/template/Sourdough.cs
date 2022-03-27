using System;
namespace template
{
    public class Sourdough : Bread
    {

        public override void Bakе()
        {
            Console.WriteLine("Baking the Sourdough Bread. (20 minutes)");
        }

        public override void MixIngredient()
        {
            Console.WriteLine("Gathering Ingredients for Sourdough Bread.");
        }
    }
}
