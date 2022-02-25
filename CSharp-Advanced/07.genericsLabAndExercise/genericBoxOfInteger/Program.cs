using System;

namespace genericBoxOfInteger
{
    public class Box<T>
    {
        public T Value { get; set; }
        public Box(T value)
        {
            Value = value;
        }


        public override string ToString()
        {
            return $"{Value.GetType()}: {Value}";
        }
    }

    public class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                Console.WriteLine(new Box<int>(int.Parse(Console.ReadLine())));
            }
        }
    }
}
