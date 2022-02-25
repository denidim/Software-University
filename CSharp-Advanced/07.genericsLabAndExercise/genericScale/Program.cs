using System;

namespace GenericScale//genericScale
{
    public class EqualityScale<T> where T: IComparable
    {
        private readonly T left;
        private readonly T right;

        public EqualityScale(T left,T right)
        {
            this.left = left;
            this.right = right;
        }

        public bool AreEqual()
        {
            return left.Equals(right);
        }
    }

    public class StartUp//Program
    {
        static void Main(string[] args)
        {
            var scale = new EqualityScale<int>(10,20);
            Console.WriteLine(scale.AreEqual());
        }
    }
}
