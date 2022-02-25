using System;

namespace tryDelegat
{
    class Program
    {
        public delegate int Calculator(int a, int b);

        static void Main(string[] args)
        {
            Calculator sumCalc = (a, b) => a + b;
            Calculator multiplyCalc = (a, b) => a * b;

            Console.WriteLine(Calculate(3,5,sumCalc));
            Console.WriteLine(Calculate(6, 8, multiplyCalc));

            Func<int, int, double> divide = (a, b) => (double)a / b;

            Console.WriteLine(Calculate(8,3 ,divide));

        }

        private static int Calculate(int a, int b, Calculator operation)
        {
            return operation(a, b);
        }
        private static double Calculate(int a, int b, Func<int, int, double> operation)
        {
            return operation(a, b);
        }
    }
}
