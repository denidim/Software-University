using System;
using System.Linq;

namespace PersonsInfo//validation
{
    public class Person
    {
        private string firstName;
        private string lastName;
        private int age;
        private decimal salary;

        public string FirstName
        {
            get => firstName;
            private set
            {
                if (value.Count() < 3)
                {
                    throw new ArgumentException("First name cannot contain fewer than 3 symbols!");
                }
                firstName = value;
            }
        }

        public string LastName
        {
            get => lastName;
            private set
            {
                if (value.Count() < 3)
                {
                    throw new ArgumentException("Last name cannot contain fewer than 3 symbols!");
                }
                lastName = value;
            }
        }

        public int Age
        {
            get => age;
            private set
            {
                if (value < 1)
                {
                    throw new ArgumentException("Age cannot be zero or a negative integer!");
                }
                age = value;
            }
        }


        public decimal Salary
        { get => salary;
            private set
            {
                if (value < 650m)
                {
                    throw new ArgumentException("Salary cannot be less than 650 leva!");
                }
                salary = value;
            }
        }


        public Person(string firstName, string lastName, int age, decimal salary)
        {
            FirstName = firstName;
            LastName = lastName;
            Age = age;
            Salary = salary;
        }


        public override string ToString()
        {
            return $"{FirstName} {LastName} receives {Salary:f2} leva.";
        }

    }

    public class StartUp
    {
        static void Main(string[] args)
        {
        }
    }
}

