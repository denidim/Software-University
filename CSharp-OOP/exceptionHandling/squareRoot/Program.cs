using System;

namespace squareRoot
{
    class Program
    {
        static void Main(string[] args)
        {

            try
            {
                int n = int.Parse(Console.ReadLine());
                Console.WriteLine(MathSqr(n));
            }
            catch(OverflowException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (ArithmeticException)
            {
                Console.WriteLine("Invalid number.");
            }
            finally
            {
                Console.WriteLine("Goodbye.");
            }
        }
        public static double MathSqr(double n)
        {
            if (n < 0)
            {
                throw new ArgumentOutOfRangeException();
            }
            return Math.Sqrt(n);
        }
    }
    
}

