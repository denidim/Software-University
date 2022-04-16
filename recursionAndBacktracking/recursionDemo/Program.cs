using System;
using System.Linq;
using System.Collections.Generic;

namespace recursionDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            //int size = int.Parse(Console.ReadLine());

            //char[][] matrix = new char[size][];
            //for (int i = 0; i < size; i++)
            //{
            //    var currRow = Console.ReadLine();
            //    matrix[i] = currRow.ToCharArray();
            //}

            Dictionary<List<int>, string> position = new Dictionary<List<int>, string>();
            position.Add(new List<int> { 0, 0 }, "D");
            List<int> arr = new List<int> { 0,0  };


            var curr = position.FirstOrDefault(x => x.Key.SequenceEqual(arr));

            position.Remove();


            // string[] maze = new string[]
            //{
            //     "010001",
            //     "01010E",
            //     "010100",
            //     "000000",
            //};

            // for (int i = 0; i < maze.Length; i++)
            // {
            //     for (int j = 0; j < maze[i].Length; j++)
            //     {

            //         Console.Write(maze[i][j]);
            //     }
            //     Console.WriteLine();
            // }

            ////Print(10);
            //int[] array = new int[] { 3, 8, 9};
            ////int sum = 0;
            ////for (int i = 0; i < array.Length; i++)
            ////{
            ////    sum += array[i];
            ////}
            //Console.WriteLine(Sum(array,0));
        }

        static int Sum(int[] array,int i)
        {
            if (i == array.Length)
            {
                return 0;
            }

            Console.WriteLine("Befor entering recursive method");

            int currSum = array[i] + Sum(array, i + 1);

            Console.WriteLine(currSum);

            Console.WriteLine("After entering recursive method");

            return currSum;
        }

        static void Print(int n)
        {
            if (n == 0)
            {
                return;
            }
            Console.WriteLine(" Somthing");
            Console.WriteLine(n);
            Print(n - 1);
        }
    }
}
