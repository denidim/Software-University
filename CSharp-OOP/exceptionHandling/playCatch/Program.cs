using System;
using System.Collections.Generic;
using System.Linq;

namespace playCatch
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] intArr = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            int count = 0;

            while (count!=3)
            {
                string[] strArr = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries);

                try
                {
                    if (strArr[0] == "Replace")
                    {
                        Replace(int.Parse(strArr[1]), int.Parse(strArr[2]) ,intArr);
                    }
                    if (strArr[0] == "Print")
                    {
                        Print(int.Parse(strArr[1]), int.Parse(strArr[2]), intArr);
                    }
                    if (strArr[0] == "Show")
                    {
                        Show(int.Parse(strArr[1]), intArr);
                    }
                }
                catch (IndexOutOfRangeException)
                {
                    count++;
                    Console.WriteLine("The index does not exist!");
                }
                catch (FormatException)
                {
                    count++;
                    Console.WriteLine("The variable is not in the correct format!");
                }
            }
            for (int i = 0; i < intArr.Length; i++)
            {
                if (i < intArr.Length - 1)
                {
                    Console.Write($"{intArr[i]}, ");
                }
                else
                {
                    Console.Write($"{intArr[i]}");
                    Console.WriteLine();
                }
            }

        }

        private static void Show(int index,int[] arr)
        {
            if (arr.Length <= index || index < 0)
            {
                throw new IndexOutOfRangeException();
            }
            else
            {
                Console.WriteLine(arr[index]);
            }
        }

        private static void Print(int startIndex, int endIndex, int[] arr)
        {
            if (arr.Length <= startIndex || startIndex < 0 ||
                arr.Length <= endIndex || endIndex < 0)
            {
                throw new IndexOutOfRangeException();
            }
            else
            {
                for (int i = startIndex; i <= endIndex; i++)
                {
                    if (i < arr.Length - 1)
                    {
                        Console.Write($"{arr[i]}, ");
                    }
                    else
                    {
                        Console.Write($"{arr[i]}");
                        Console.WriteLine();
                    }
                }
            }
            
        }

        public static void Replace(int index,int element,int[] arr)
        {
            if (arr.Length <= index || index < 0)
            {
                throw new IndexOutOfRangeException();
            }
            else
            {
                arr[index] = element;
            }
        }
    }
}
