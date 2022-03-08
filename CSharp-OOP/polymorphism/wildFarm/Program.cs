using System;
using System.Collections.Generic;
using wildFarm.Models;
using wildFarm.Models.Animals;
using wildFarm.Models.Animals.Mamals;
using wildFarm.Models.Foods;

namespace wildFarm
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            List<Animal> animals = new List<Animal>();

            List<Food> foods = new List<Food>();
            int animalCount = 0;
            int counter = 0;
            string command;
            while ((command = Console.ReadLine()) != "End")
            {
                string[] tokens = command.Split();

                if (counter % 2 == 0)
                {
                    if (tokens[0] == "Cat" || tokens[0] == "Tiger")
                    {
                        //{Type} {Name} {Weight} {LivingRegion} {Breed}"
                        string name = tokens[1];
                        double weight = double.Parse(tokens[2]);
                        string region = tokens[3];
                        string bread = tokens[4];
                        if (tokens[0] == "Cat")
                        {
                            Cat cat = new Cat(name, weight, region, bread);
                            animals.Add(cat);
                        }
                        else
                        {
                            Tiger tiger = new Tiger(name, weight, region, bread);
                            animals.Add(tiger);
                        }

                    }
                    if (tokens[0] == "Dog" || tokens[0] == "Mouse")
                    {
                        //"{Type} {Name} {Weight} {LivingRegion}"
                        string name = tokens[1];
                        double weight = double.Parse(tokens[2]);
                        string region = tokens[3];
                        if (tokens[0] == "Dog")
                        {
                            Dog dog = new Dog(name, weight, region);
                            animals.Add(dog);
                        }
                        else
                        {
                            Mouse mouse = new Mouse(name, weight, region);
                            animals.Add(mouse);
                        }
                    }
                    if (tokens[0] == "Hen" || tokens[0] == "Owl")
                    {
                        //"{Type} {Name} {Weight} {WingSize}"
                        string name = tokens[1];
                        double weight = double.Parse(tokens[2]);
                        double wingSize = double.Parse(tokens[3]);
                        if (tokens[0] == "Hen")
                        {
                            Hen hen = new Hen(name, weight, wingSize);
                            animals.Add(hen);
                        }
                        else
                        {
                            Owl owl = new Owl(name, weight, wingSize);
                            animals.Add(owl);
                        }
                    }
                }
                else
                {
                    string foodType = tokens[0];
                    int foodQuantity = int.Parse(tokens[1]);
                    if (foodType == "Vegetable")
                    {
                        Vegetable vegetable = new Vegetable(foodQuantity);
                        foods.Add(vegetable);
                    }
                    if (foodType == "Fruit")
                    {
                        Fruit fruit = new Fruit(foodQuantity);
                        foods.Add(fruit);
                    }
                    if (foodType == "Meat")
                    {
                        Meat meat = new Meat(foodQuantity);
                        foods.Add(meat);
                    }
                    if (foodType == "Seeds")
                    {
                        Seeds seeds = new Seeds(foodQuantity);
                        foods.Add(seeds);
                    }
                    for (int i = animalCount; i < animals.Count; i++)
                    {
                        var currAnimal = animals[i];
                        var currFood = foods[i];
                        Console.WriteLine(currAnimal.ProduseSound());
                        if (currAnimal.ProduseSound() == "Cluck")//Hen
                        {
                            currAnimal.FoodEaten += currFood.Quantity;
                            currAnimal.Weight += 0.35*currFood.Quantity;
                        }
                        if (currAnimal.ProduseSound() == "Squeak")//Mouse
                        {
                            if (currFood.GetType().Name == "Vegetable"
                            || currFood.GetType().Name == "Fruit")
                            {
                                currAnimal.FoodEaten += currFood.Quantity;
                                currAnimal.Weight += 0.10 * currFood.Quantity;
                            }
                            else
                            {
                                Console.WriteLine($"{currAnimal.GetType().Name} does not eat {currFood.GetType().Name}!");
                            }
                        }
                        if (currAnimal.ProduseSound() == "Meow")
                        {
                            if (currFood.GetType().Name == "Vegetable"
                            || currFood.GetType().Name == "Meat")
                            {
                                currAnimal.FoodEaten += currFood.Quantity;
                                currAnimal.Weight += 0.30 * currFood.Quantity;
                            }
                            else
                            {
                                Console.WriteLine($"{currAnimal.GetType().Name} does not eat {currFood.GetType().Name}!");
                            }
                        }
                        if (currAnimal.ProduseSound() == "Hoot Hoot")
                        {
                            if (currFood.GetType().Name == "Meat")
                            {
                                currAnimal.FoodEaten += currFood.Quantity;
                                currAnimal.Weight += 0.25 * currFood.Quantity;
                            }
                            else
                            {
                                Console.WriteLine($"{currAnimal.GetType().Name} does not eat {currFood.GetType().Name}!");
                            }
                        }
                        else if (currAnimal.ProduseSound() == "Woof!")
                        {
                            if (currFood.GetType().Name == "Meat")
                            {
                                currAnimal.FoodEaten += currFood.Quantity;
                                currAnimal.Weight += 0.40 * currFood.Quantity;
                            }
                            else
                            {
                                Console.WriteLine($"{currAnimal.GetType().Name} does not eat {currFood.GetType().Name}!");
                            }
                        }
                        else if (currAnimal.ProduseSound() == "ROAR!!!")
                        {
                            if (currFood.GetType().Name == "Meat")
                            {
                                currAnimal.FoodEaten += currFood.Quantity;
                                currAnimal.Weight += 1.00 * currFood.Quantity;
                            }
                            else
                            {
                                Console.WriteLine($"{currAnimal.GetType().Name} does not eat {currFood.GetType().Name}!");
                            }
                        }
                    }
                    animalCount++;
                }
                counter++;
            }
            foreach (var item in animals)
            {
                Console.WriteLine(item);
            }
        }
    }
}
