using System;
using System.Collections.Generic;
using System.Linq;

namespace pizzaCalories
{
    public class Pizza
    {
        private string name;
        private List<Topping> toppings;
        private Dough dough;

        public Pizza(string name,Dough dough)
        {
            this.Name = name;
            this.Dough = dough;

            this.toppings = new List<Topping>();
        }

        public string Name
        {
            get => name;
            private set
            {
                if (value.Length < 1 || value.Length > 15)
                {
                    throw new Exception("Pizza name should be between 1 and 15 symbols.");
                }
                name = value;
            }
        }
        public Dough Dough
        {
            get => dough;
            private set => dough = value;
        }

        public IReadOnlyCollection<Topping> Toppings => this.toppings.AsReadOnly();

        public void AddTopping(Topping topping)
        {
            if (toppings.Count >= 10)
            {
                throw new Exception("Number of toppings should be in range [0..10].");
            }

            toppings.Add(topping);
        }

        public double CalculateTotalCalories()
        {
            return Dough.calories + toppings.Sum(x => x.calories);
        }
    }

    public class Topping
    {
        private Dictionary<string, double> toppingsTypeValue = new Dictionary<string, double>
        {
            {"meat" ,1.2},
            {"veggies" ,0.8},
            {"cheese" ,1.1},
            {"sauce" ,0.9},
        };

        //meat, veggies, cheese, or a sauce.
        private string type;
        private double weigth;

        public Topping(string type,double weigth)
        {
            Type = type;
            Weigth = weigth;
        }

        public string Type
        {
            get => type;
            private set
            {
                    if (!toppingsTypeValue.ContainsKey(value.ToLower()))
                    {
                        throw new Exception($"Cannot place {value} on top of your pizza.");
                    }
                type = value;
            }
        }
        public double Weigth
        {
            get => weigth;
            private set
            {
                if (value<1||value>50)
                {
                    throw new Exception($"{Type} weight should be in the range [1..50].");
                }

                weigth = value;
            }
        }
        public double calories
        {
            get => 2 * Weigth * toppingsTypeValue[Type.ToLower()];
        }
    }

    public class Dough
    {
        private Dictionary<string, double> flourTypeValue = new Dictionary<string, double>
        {
            {"white", 1.5 },
            {"wholegrain" , 1.0},
        };

        private Dictionary<string, double> bakingTypeValue = new Dictionary<string, double>
        {
            {"crispy", 0.9},
            {"chewy" , 1.1 },
            {"homemade", 1.0 },
        };

        private string flour;
        private string bakingTechnique;
        private double weigth;

        public string Flour
        {
            get => flour;

            private set
            {
                if (!flourTypeValue.ContainsKey(value.ToLower()))
                {
                    throw new Exception("Invalid type of dough.");
                }
                flour = value;
            }
        }

        public string BakingTechnique
        {
            get => bakingTechnique;
            private set
            {
                if (!bakingTypeValue.ContainsKey(value.ToLower()))
                {
                    throw new Exception("Invalid type of dough.");
                }
                bakingTechnique = value;
            }
        }

        public double Weigth
        {
            get => weigth;

            private set
            {
                if (value < 0 || value > 200)
                {
                    throw new Exception("Dough weight should be in the range [1..200].");
                }
                weigth = value;
            }
        }

        public double calories
        {
            get => 2 * Weigth * flourTypeValue[Flour.ToLower()] * bakingTypeValue[BakingTechnique.ToLower()];
        }

        //Dough White Chewy 100
        public Dough(string flour,string bakingTechnique,double weigth)
        {
            Flour = flour;
            BakingTechnique = bakingTechnique;
            Weigth = weigth;
        }
    }

    public class StartUp
    {
        static void Main(string[] args)
        {
            try
            {
                string[] pizzaInfo = Console.ReadLine().Split();
                string[] toppingInfo = Console.ReadLine().Split();

                Dough dough = new Dough(toppingInfo[1], toppingInfo[2], double.Parse(toppingInfo[3]));

                Pizza pizza = new Pizza(pizzaInfo[1], dough);

                while (true)
                {
                    string[] input = Console.ReadLine().Split();
                    if (input[0] == "END")
                    {
                        break;
                    }
                    Topping topping = new Topping(input[1], double.Parse(input[2]));

                    pizza.AddTopping(topping);
                }

                Console.WriteLine($"{pizza.Name} - {pizza.CalculateTotalCalories():f2} Calories.");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}


    