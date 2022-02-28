using System;
using System.Text;

namespace Animals
{
    public abstract class Animal
    {
        private string _name;
        private int _age;
        private string _gender;

        public string Name
        {
            get
            {
                return _name;
            }
            set
            {
                if (value == string.Empty)
                {
                    throw new Exception("Invalid input!");
                }
                else
                {
                    _name = value;
                }
            }
        }
        public int Age
        {
            get => _age;
            set
            {
                if (value.ToString() == string.Empty || value<0)
                {
                    throw new Exception("Invalid input!");
                }
                _age = value;
            }
        }
        public string Gender
        {
            get => _gender;
            set
            {
                if (value == string.Empty)
                {
                    throw new Exception("Invalid input!");
                }
                _gender = value;
            }
        }

        public Animal(string name, int age, string gender)
        {
            Name = name;
            Age = age;
            Gender = gender;
        }

        public abstract string ProduceSound();

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"{this.GetType().Name}");

            sb.AppendLine($"{this.Name} {this.Age} {this.Gender}");

            sb.AppendLine(this.ProduceSound());

            return sb.ToString().TrimEnd();
        }
    }

    public class Cat : Animal
    {
        public Cat(string name, int age, string gender) : base(name, age, gender)
        {
        }


        public override string ProduceSound()
        {
            return "Meow meow";
        }
    }

    public class Kitten : Cat
    {
        private const string ConstGender = "Female";

        public Kitten(string name, int age) : base(name, age,
           ConstGender)
        {
        }

        public override string ProduceSound()
        {
            return "Meow";
        }
    }

    public class Tomcat : Cat
    {
        private const string ConstGender = "Male";

        public Tomcat(string name, int age) : base(name, age, ConstGender)
        {

        }

        public override string ProduceSound()
        {
            return "MEOW";
        }

    }

    public class Dog : Animal
    {
        public Dog(string name, int age, string gender) : base(name, age, gender)
        {
        }
        public override string ProduceSound()
        {
            return "Woof!";
        }
    }

    public class Frog : Animal
    {
        public Frog(string name, int age, string gender) : base(name, age, gender)
        {
        }

        public override string ProduceSound()
        {
            return "Ribbit";
        }
    }

    public class StartUp//class Program
    {
        static void Main(string[] args)
        {
            StringBuilder sb = new StringBuilder();

            string input;
            while ((input = Console.ReadLine()) != "Beast!")
            {
                string[] properties = Console.ReadLine().Split();

                Animal animal;
                if (input == "Cat")
                {
                    try
                    {
                        animal = new Cat(properties[0], int.Parse(properties[1]), properties[2]);
                        sb.AppendLine(animal.ToString());
                    }
                    catch (Exception ex)
                    {
                        sb.AppendLine(ex.Message);
                    }
                }
                if (input == "Dog")
                {
                    try
                    {
                        animal = new Dog(properties[0], int.Parse(properties[1]), properties[2]);
                        sb.AppendLine(animal.ToString());
                    }
                    catch (Exception ex)
                    {
                        sb.AppendLine(ex.Message);
                        
                    }
                }
                if (input == "Frog")
                {
                    try
                    {
                        animal = new Frog(properties[0], int.Parse(properties[1]), properties[2]);
                        sb.AppendLine(animal.ToString());
                    }
                    catch (Exception ex)
                    {
                        sb.AppendLine(ex.Message);
                    }
                }
                if (input == "Kitten")
                {
                    try
                    {
                        animal = new Kitten(properties[0], int.Parse(properties[1]));
                        sb.AppendLine(animal.ToString());
                    }
                    catch (Exception ex)
                    {
                        sb.AppendLine(ex.Message);
                    }
                }
                if (input == "Tomcat")
                {
                    try
                    {
                        animal = new Tomcat(properties[0], int.Parse(properties[1]));
                        sb.AppendLine(animal.ToString());
                    }
                    catch (Exception ex)
                    {
                        sb.AppendLine(ex.Message);
                    }
                }
            }
            Console.WriteLine(sb.ToString().TrimEnd());
        }
    }
}
