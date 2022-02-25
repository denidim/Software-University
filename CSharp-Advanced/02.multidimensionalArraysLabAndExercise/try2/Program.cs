using System;
using System.Linq;

namespace try2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] dimensions = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            string[][] matrix = new string[dimensions[0]][];

            for (int i = 0; i < matrix.Length; i++)
            {
                matrix[i] = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            }
            int rowIndex = 0;
            int columnIndex = 0;
            int swapRowIndex =0;
            int swapColIndex = 0;


            string command = Console.ReadLine().ToUpper();

            while (command != "END")
            {
                bool isValid = false;

                string[] tokens = command.Split(" ", StringSplitOptions.RemoveEmptyEntries);

                if (command.StartsWith("SWAP"))
                {
                    isValid = true;
                    rowIndex = int.Parse(tokens[1]);
                    columnIndex = int.Parse(tokens[2]);
                    swapRowIndex = int.Parse(tokens[3]);
                    swapColIndex = int.Parse(tokens[4]);

                    if(rowIndex < 0 || rowIndex >= dimensions[0] ||
                    columnIndex < 0 || columnIndex >= dimensions[1] ||
                   swapRowIndex < 0 || swapRowIndex >= dimensions[0] ||
                   swapColIndex < 0 || swapColIndex > matrix.Length)
                    {
                        isValid = false;
                    }
                    else
                    {
                        isValid = true;
                    }
                }
                else
                {
                    isValid = false;
                }

                if (isValid == false)
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
