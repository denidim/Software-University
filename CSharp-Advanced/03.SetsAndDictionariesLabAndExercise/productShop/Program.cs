using System;
using System.Linq;
using System.Collections.Generic;

namespace productShop
{
    class Program
    {
        static void Main(string[] args)
        {
            SortedDictionary<string, Dictionary<string, double>> shops =
                new SortedDictionary<string, Dictionary<string, double>>();

            string command;
            while ((command= Console.ReadLine())!= "Revision")
            {
                string[] tockens = command.Split(", ",StringSplitOptions.RemoveEmptyEntries);

                string shop = tockens[0];
                string product = tockens[1];
                double price = double.Parse(tockens[2]);

                if (!shops.ContainsKey(shop))
                {
                    shops.Add(shop, new Dictionary<string,double>());
                    if (!shops[shop].ContainsKey(product))
                    {
                        shops[shop].Add(product, price);
                    }
                }
                else
                {
                    shops[shop].Add(product, price);
                }
            }
            foreach (var shop in shops)
            {
                Console.WriteLine($"{shop.Key}->");

                foreach (var product in shop.Value)
                {
                    Console.WriteLine($"Product: {product.Key}, Price: {product.Value}");
                }
            }

        }
    }
}
