using System;
using System.Linq;
using System.Text;

namespace jaggedArrayModification
{
    class Program
    {
        static StringBuilder sb = new StringBuilder();

        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            int[][] jagged = FillingJaggedArray(n);

            HandlingCommands(jagged);

            PrintJagged(n, jagged);
        }
        private static void PrintJagged(int n, int[][] jagged)
        {
            Console.WriteLine(sb);

            for (int i = 0; i < n; i++)
            {
                Console.WriteLine(string.Join(" ", jagged[i]));
            }
        }
        private static int[][] FillingJaggedArray(int n)
        {
            int[][] jagged = new int[n][];
            for (int i = 0; i < n; i++)
            {
                jagged[i] = ReadRow();
            }
            return jagged;
        }
        private static void HandlingCommands(int[][] jagged)
        {
            while (true)
            {
                string[] command = Console.ReadLine().ToUpper().Split();
                if (command[0] == "END")
                {
                    break;
                }
                if (command[0] == "ADD")
                {
                    Add(jagged, command);
                    continue;
                }
                if (command[0] == "SUBTRACT")
                {
                    Subtract(jagged, command);
                    continue;
                }
            }
            
        }
        public static void Subtract(int[][] jagged, string[] command)
        {
            int row = int.Parse(command[1]);
            int col = int.Parse(command[2]);
            int value = int.Parse(command[3]);
            if (row > -1 && row < jagged.Length && col > -1 && col < jagged[row].Length)
            {
                jagged[row][col] -= value;
            }
            else
            {
                sb.AppendLine("Invalid coordinates");
            }
        }
        private static void Add(int[][] jagged, string[] command)
        {
            int row = int.Parse(command[1]);
            int col = int.Parse(command[2]);
            int value = int.Parse(command[3]);
            if (row > -1 && row < jagged.Length && col > -1 && col < jagged[row].Length)
            {
                jagged[row][col] += value;
            }
            else
            {
                sb.AppendLine("Invalid coordinates");
            }
        }

        private static int[] ReadRow()
        {
            return Console.ReadLine()
                .Split(" ",StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
        }
    }
}
