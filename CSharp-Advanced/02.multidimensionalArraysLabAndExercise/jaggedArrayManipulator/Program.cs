using System;
using System.Linq;

namespace jaggedArrayManipulator
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            double[][] jagged = FillArray(n);
            MultiplyOrDivide(jagged);
            SetCommands(jagged);
            Print(n, jagged);
        }

        private static void Print(int n, double[][] jagged)
        {
            for (int i = 0; i < n; i++)
            {
                Console.WriteLine(string.Join(" ", jagged[i]));
            }
        }

        private static void MultiplyOrDivide(double[][] jagged)
        {
            for (int i = 0; i < jagged.Length - 1; i++)
            {
                if (jagged[i].Length == jagged[i + 1].Length)
                {
                    for (int k = 0; k < jagged[i].Length; k++)
                    {
                        jagged[i][k] *= 2;
                    }
                    for (int j = 0; j < jagged[i + 1].Length; j++)
                    {
                        jagged[i + 1][j] *= 2;
                    }
                }
                else
                {
                    for (int k = 0; k < jagged[i].Length; k++)
                    {
                        jagged[i][k] /= 2;
                    }
                    for (int j = 0; j < jagged[i + 1].Length; j++)
                    {
                        jagged[i + 1][j] /= 2;
                    }
                }
            }
        }
        private static double[][] FillArray(int n)
        {

            double[][] jagged = new double[n][];
            for (int i = 0; i < n; i++)
            {
                jagged[i] = ReadArray();
            }
            return jagged;
        }
        private static double[] ReadArray()
        {
            return Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .Select(double.Parse)
                    .ToArray();
        }

        private static void SetCommands(double[][] jagged)
        {
            while (true)
            {
                string[] commands = ReadCommands();
                if (commands[0] == "end")
                {
                    break;
                }
                int row = int.Parse(commands[1]);
                int column = int.Parse(commands[2]);
                int value = int.Parse(commands[3]);

                bool isValid = ValidateIndexFromInput(row, column, jagged);

                if (isValid)
                {
                    EmplementCommands(jagged, commands, row, column, value);
                }
            }
        }

        private static string[] ReadCommands()
        {
            return Console.ReadLine()
                .ToLower()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries);
        }

        private static void EmplementCommands(double[][] jagged, string[] commands, int row, int column, int value)
        {
            if (commands[0] == "add")
            {
                jagged[row][column] += value;
            }
            if (commands[0] == "subtract")
            {
                jagged[row][column] -= value;
            }
        }

        private static bool ValidateIndexFromInput(int row, int col, double[][] jagged)
        {
            return row >= 0 && row < jagged.GetLength(0) &&
                   col >= 0 && col < jagged[row].Length;
        }
    }
}

