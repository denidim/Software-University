
using System;

namespace EightQueensProblem
{
    class Program
    {
        static void Main(string[] args)
        {
            int queens = int.Parse(Console.ReadLine());

            int[,] matrix = new int[queens, queens];

            Console.WriteLine(GetQueens(matrix, 0));
        }

        private static int GetQueens(int[,] queens, int row)
        {
            if (row == queens.GetLength(0))
            {
                PrintQueens(queens);
                return 1;
            }
            int foundQueens = 0;

            for (int col = 0; col < queens.GetLength(1); col++)
            {
                if (IsSafe(queens, row, col))
                {
                    queens[row, col] = 1;
                    foundQueens+=GetQueens(queens, row + 1);
                    queens[row, col] = 0;
                }
            }
            return foundQueens;
        }

        static void PrintQueens(int[,] queens)
        {
            for (int row = 0; row < queens.GetLength(0); row++)
            {
                for (int col = 0; col < queens.GetLength(1); col++)
                {
                    if (queens[row, col] == 1)
                    {
                        Console.Write("Q" + " ");
                    }
                    if (queens[row, col] == 0)
                    {
                        Console.Write("_" + " ");
                    }
                }
                Console.WriteLine();
            }
            Console.WriteLine();
            Console.WriteLine(new string('=', 20));
        }

        private static bool IsSafe(int[,] queens, int row, int col)
        {
            for (int i = 1; i < queens.GetLength(0); i++)
            {
                if (row - i >= 0 && queens[row - i, col] == 1)
                {
                    return false;
                }
                if (col - i >= 0 && queens[row, col-i] == 1)
                {
                    return false;
                }
                if (row + i < queens.GetLength(0) && queens[row + i, col] == 1)
                {
                    return false;
                }
                if (col + i < queens.GetLength(0) && queens[row, col + i] == 1)
                {
                    return false;
                }
                if (col + i < queens.GetLength(0) &&
                    row + i < queens.GetLength(0) &&
                    queens[row + i, col + i] == 1)
                {
                    return false;
                }
                if (col - i >= 0 &&
                    row + i < queens.GetLength(0) &&
                    queens[row + i, col - i] == 1)
                {
                    return false;
                }
                if (col - i >= 0 &&
                    row - i >= 0 &&
                    queens[row - i, col - i] == 1)
                {
                    return false;
                }
                if (col + i < queens.GetLength(0) &&
                    row - i >= 0 &&
                    queens[row - i, col + i] == 1)
                {
                    return false;
                }
            }
            return true;
        }
    }
}
