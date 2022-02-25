using System;
using System.Linq;

namespace try1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] dimensions = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            int[][] matrix = new int[dimensions[0]][];

            for (int i = 0; i < matrix.Length; i++)
            {
                matrix[i] = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            }

            string command = Console.ReadLine().ToUpper();

            while (command != "END")
            {
                string[] tokens = command.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string action = tokens[0];
                int rowIndex = int.Parse(tokens[1]);
                int columnIndex = int.Parse(tokens[2]);
                int swapRowIndex = int.Parse(tokens[3]);
                int swapColIndex = int.Parse(tokens[4]);

                if (!command.StartsWith("SWAP") ||
                    tokens.Length != 5 ||
                    rowIndex < 0 || rowIndex >= dimensions[0] ||
                    columnIndex < 0 || columnIndex >= dimensions[1] ||
                    swapRowIndex < 0 || swapRowIndex >= dimensions[0] ||
                    swapColIndex < 0 || swapColIndex > matrix.Length)
                {
                    Console.WriteLine($"Invalid input!");
                    command = Console.ReadLine().ToUpper();
                    continue;
                }

                else
                {
                    var tempIndex = matrix[rowIndex][columnIndex];
                    matrix[rowIndex][columnIndex] = matrix[swapRowIndex][swapColIndex];
                    matrix[swapRowIndex][swapColIndex] = tempIndex;

                    for (int i = 0; i < matrix.Length; i++)
                    {
                        Console.WriteLine(string.Join(" ", matrix[i]));
                    }

                    command = Console.ReadLine().ToUpper();
                }

            }
        }
    }
}
