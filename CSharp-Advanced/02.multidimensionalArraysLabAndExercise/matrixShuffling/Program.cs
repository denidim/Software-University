using System;
using System.Linq;

namespace matrixShuffling
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] size = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            string[,] matrix = new string[size[0], size[1]];

            for (int i = 0; i < size[0]; i++)
            {
                FillingMAtrix(size, matrix, i);
            }
            int[] toSwap = new int[2];
            int[] with = new int[2];
            while (true)
            {
                bool isValid = false;

                string[] commands = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                if (commands[0] == "END")
                {
                    break;
                }
                if (commands.Length == 5)
                {
                    isValid = ValidatingInput(size, toSwap, with, isValid, commands);
                }

                if (isValid)
                {
                    string curr = matrix[toSwap[0], toSwap[1]];
                    matrix[toSwap[0], toSwap[1]] = matrix[with[0], with[1]];
                    matrix[with[0], with[1]] = curr;

                    for (int i = 0; i < size[0]; i++)
                    {
                        for (int j = 0; j < size[1]; j++)
                        {
                            Console.Write($"{matrix[i,j]} ");
                        }
                        Console.WriteLine();
                    }
                }
                else
                {
                    Console.WriteLine("Invalid input!");
                }
            }
        }

        private static bool ValidatingInput(int[] size, int[] toSwap, int[] with, bool isValid, string[] commands)
        {
            if (commands[0] == "swap")
            {
                toSwap[0] = int.Parse(commands[1]);
                toSwap[1] = int.Parse(commands[2]);

                with[0] = int.Parse(commands[3]);
                with[1] = int.Parse(commands[4]);
                if (toSwap[0] > -1 && toSwap[0] < size[0] &&
                    toSwap[1] > -1 && toSwap[1] < size[1])
                {

                    if (with[0] > -1 && with[0] < size[0] &&
                        with[1] > -1 && with[1] < size[1])
                    {
                        isValid = true;
                    }
                }
            }

            return isValid;
        }

        private static void FillingMAtrix(int[] size, string[,] matrix, int i)
        {
            string[] row = Console.ReadLine()
                            .Split(" ", StringSplitOptions.RemoveEmptyEntries);
            for (int j = 0; j < size[1]; j++)
            {
                matrix[i, j] += row[j];
            }
        }
    }
}
