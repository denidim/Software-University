using System;

namespace AnimalFarm.Models
{
    public class Chicken
    {
        private const int MinAge = 0;
        private const int MaxAge = 15;

        protected string _name;
        internal int _age;

        public Chicken(string name, int age)
        {
            this.Name = name;
            this.Age = age;
        }

        public string Name
        {
            get => _name;

            private set
            {
                if (String.IsNullOrWhiteSpace(value))
                {
                    throw new Exception("Name cannot be empty.");
                }
                this._name = value;
            }
        }

        public int Age
        {
            get => _age;

            private set
            {
                if (value < MinAge || value > MaxAge)
                {
                    throw new ArgumentException($"{nameof(Age)} should be between {MinAge} and {MaxAge}.");
                }
                this._age = value;
            }
        }

        public double ProductPerDay
        {
			get
			{				
				return this.CalculateProductPerDay();
			}
        }

        private double CalculateProductPerDay() => this.Age switch
        {
            var x when x >= 0 &&  x < 4 => 1.5,
            var x when x>= 4 && x < 8 => 2,
            var x when x >= 8 && x < 12 => 1,
            _ =>0.75

            //switch (this.Age)
            //{
            //    case 0:
            //    case 1:
            //    case 2:
            //    case 3:
            //        return 1.5;
            //    case 4:
            //    case 5:
            //    case 6:
            //    case 7:
            //        return 2;
            //    case 8:
            //    case 9:
            //    case 10:
            //    case 11:
            //        return 1;
            //    default:
            //        return 0.75;
            //}
        };
    }
}
