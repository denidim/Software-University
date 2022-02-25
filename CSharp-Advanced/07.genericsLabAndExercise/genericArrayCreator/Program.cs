using System;

namespace GenericArrayCreator//genericArrayCreator
{
    public class ArrayCreator
    {
        public static T[] Create<T>(int length,T item)
        {
            T[] result = new T[length];

            for (int i = 0; i < length; i++)
            {
                result[i] = item;
            }

            return result;
        }
    }

    public class StartUp//Program
    {
        static void Main(string[] args)
        {
            string[] strings = ArrayCreator.Create(5, "Pesho");
            int[] integers = ArrayCreator.Create(10, 33);

        }
    }
}
