using System;
using System.Linq;

namespace prototype
{
    class Program
    {
        static void Main(string[] args)
        {
            SandwichMenu sandwichMenu = new SandwichMenu();


            sandwichMenu["Blt"] =
                new Sandwich("Wheat", "Bacon", "", "Lettuce, Tomato");

            Sandwich blt = sandwichMenu.sandwiches.Values.First() as Sandwich;


            Sandwich newBLT = sandwichMenu["Blt"].ShallowCopy() as Sandwich;

            newBLT.veggies = "domati";

            Console.WriteLine(blt.veggies);
            Console.WriteLine(newBLT.veggies);

        }
    }
}