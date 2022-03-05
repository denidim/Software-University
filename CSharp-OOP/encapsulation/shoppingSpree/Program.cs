using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ShoppingSpree//shoppingSpree
{
    public class Product
    {
        private string _name;
        private decimal _cost;

        public string Name
        {
            get => _name;

            private set
            {
                if (String.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Name cannot be empty");
                }
                _name = value;
            }
        }

        public decimal Cost
        {
            get => _cost;

            private set
            {
                if (value < 0)
                {
                    throw new Exception("Money cannot be negative");
                }

                _cost = value;
            }
        }

        public Product(string name, decimal cost)
        {
            Name = name;
            Cost = cost;
        }

    }

    public class Person
    {
        private string _name;
        private decimal _money;
        private  List<Product> _bag;

        public string Name
        {
            get => _name;

            private set
            {
                if (String.IsNullOrWhiteSpace(value))
                {
                    throw new Exception("Name cannot be empty");
                }
                _name = value;
            }
        }

        public decimal Money
        {
            get => _money;

            private set
            {
                if (value < 0)
                {
                    throw new Exception("Money cannot be negative");
                }

                _money = value;
            }
        }

        public IReadOnlyCollection<Product> Bag
        {
            get => _bag;
        }

        public Person(string name, decimal money)
        {
            Name = name;
            Money = money;
            _bag = new List<Product>();
        }

        public string Buy(Product currProduct)
        {

            if (Money >= currProduct.Cost)
            {
                Money -= currProduct.Cost;

                _bag.Add(currProduct);

                return $"{this.Name} bought {currProduct.Name}";
            }

            return $"{this.Name} can't afford {currProduct.Name}";
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            if (_bag.Count > 0)
            {
               return sb.AppendLine(Name + " - " + string.Join(", ", _bag.Select(x => x.Name))).ToString().TrimEnd();
            }

            return sb.AppendLine(Name + " - " + "Nothing bought").ToString().TrimEnd();

        }

    }

    public class StartUp
    {
        static void Main(string[] args)
        {
            try
            {
                var peopleList = new List<Person>();

                string[] people = Console.ReadLine().Split(";", StringSplitOptions.RemoveEmptyEntries);

                for (int i = 0; i < people.Length; i++)
                {
                    string name = people[i].Split("=")[0];
                    decimal money = decimal.Parse(people[i].Split("=")[1]);
                    peopleList.Add(new Person(name, money));
                }

                var productList = new List<Product>();

                string[] products = Console.ReadLine().Split(";", StringSplitOptions.RemoveEmptyEntries);

                for (int i = 0; i < products.Length; i++)
                {
                    string name = products[i].Split("=")[0];
                    decimal price = decimal.Parse(products[i].Split("=")[1]);
                    productList.Add(new Product(name, price));
                }

                StringBuilder sb = new StringBuilder();

                string command;

                while ((command = Console.ReadLine()) != "END")
                {
                    string name = command.Split()[0];
                    string product = command.Split()[1];

                    var currPerson = peopleList.Find(x => x.Name == name);
                    var currProduct = productList.Find(x => x.Name == product);

                    sb.AppendLine(currPerson.Buy(currProduct));
                }

                Console.WriteLine(sb.ToString().TrimEnd());
                sb.Clear();

                foreach (var item in peopleList)
                {
                    Console.WriteLine(item);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
