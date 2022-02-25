using System;

namespace knightGame
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            char[][] jagged = new char[n][];
            for (int i = 0; i < n; i++)
            {
                jagged[i] = Console.ReadLine().ToCharArray();
            }

            int[,] possibleMooves = new int[n,n];

            int removed = 0;
            while (true)
            {
                int maxCountMoves = int.MinValue;
                int row = 0;
                int col = 0;
                for (int i = 0; i < n; i++)
                {
                    for (int j = 0; j < n; j++)
                    {
                        if (jagged[i][j] == 'K')
                        {
                            if (i - 1 > -1 && i - 1 < jagged.Length && j - 2 > -1 && j - 2 < jagged[i - 1].Length)
                            {
                                if (jagged[i - 1][j - 2] == 'K')
                                {
                                    possibleMooves[i,j]++;
                                }
                            }
                            if (i - 1 > -1 && i - 1 < jagged.Length && j + 2 > -1 && j + 2 < jagged[i - 1].Length)
                            {
                                if (jagged[i - 1][j + 2] == 'K' )
                                {
                                    possibleMooves[i, j]++;
                                }
                            }

                            if (i + 1 > -1 && i + 1 < jagged.Length && j - 2 > -1 && j - 2 < jagged[i + 1].Length)
                            {
                                if (jagged[i + 1][j - 2] == 'K' )
                                {
                                    possibleMooves[i, j]++;
                                }
                            }
                            if (i + 1 > -1 && i + 1 < jagged.Length && j + 2 > -1 && j + 2 < jagged[i + 1].Length)
                            {
                                if (jagged[i + 1][j + 2] == 'K' )
                                {
                                    possibleMooves[i, j]++;
                                }
                            }
                            if (i - 2 > -1 && i - 2 < jagged.Length && j - 1 > -1 && j - 1 < jagged[i - 2].Length)
                            {
                                if (jagged[i - 2][j - 1] == 'K' )
                                {
                                    possibleMooves[i, j]++;
                                }
                            }
                            if (i - 2 > -1 && i - 2 < jagged.Length && j + 1 > -1 && j + 1 < jagged[i - 2].Length)
                            {
                                if (jagged[i - 2][j + 1] == 'K' )
                                {
                                    possibleMooves[i, j]++;
                                }
                            }
                            if (i + 2 > -1 && i + 2 < jagged.Length && j - 1 > -1 && j - 1 < jagged[i + 2].Length)
                            {
                                if (jagged[i + 2][j - 1] == 'K' )
                                {
                                    possibleMooves[i, j]++;

                                }
                            }
                            if (i + 2 > -1 && i + 2 < jagged.Length && j + 1 > -1 && j + 1 < jagged[i + 2].Length)
                            {
                                if (jagged[i + 2][j + 1] == 'K' )
                                {
                                    possibleMooves[i, j]++;
                                }
                            }
                            
                        }
                    }
                }
                for (int i = 0; i < n; i++)
                {
                    for (int j = 0; j < n; j++)
                    {
                        if (possibleMooves[i,j] > maxCountMoves)
                        {
                            maxCountMoves = possibleMooves[i, j];
                            row = i;
                            col = j;
                        }
                    }
                }
                if (maxCountMoves > 0)
                {
                    jagged[row][col] = '0';
                    removed++;
                    possibleMooves = new int[n,n];
                }
                else
                {
                    break;
                }
            }
            Console.WriteLine(removed);
        }
    }
}

