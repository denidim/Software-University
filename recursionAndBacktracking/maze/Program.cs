using System;

namespace maze
{
    class Program
    {
        static void Main(string[] args)
        {
            //int rows = int.Parse(Console.ReadLine());
            //int cols = int.Parse(Console.ReadLine());
            //char[,] maze = new char[rows, cols];
            //for (int i = 0; i < rows; i++)
            //{
            //    string input = Console.ReadLine();
            //    for (int j = 0; j < cols; j++)
            //    {
            //        maze[i, j] += input[j];
            //    }
            //}

            //char[,] maze = new char[,]
            //{
            //    { '-','-','-' ,'-'},
            //    { '*','-','*' ,'-'},
            //    { '-','-','*' ,'-'},
            //    { '-','*','-' ,'-'},
            //    { '-','-','-' ,'E'},
            //};

            char[,] maze = new char[,]
            {
                { '-','-','-'},
                { '-','*','-'},
                { '-','*','E'},
            };

            int row = 0;
            int col = 0;
            bool[,] visited = new bool[maze.GetLength(0), maze.GetLength(1)];
            string path = "";

            FindPath(maze, row, col, visited, path);
        }

        private static void FindPath(char[,] maze, int row, int col, bool[,] visited, string path)
        {
            if (maze[row,col] == 'E')
            {
                Console.WriteLine("Path: " + path);
                Print(maze);
                return;
            }

            visited[row, col] = true;

            if (IsSafe(maze, row + 1, col, visited))
            {
                if (maze[row + 1,col] != 'E')
                    maze[row + 1,col] = 'D';

                FindPath(maze, row + 1, col, visited, path + 'D');
            }
            if (IsSafe(maze, row - 1, col, visited))
            {
                if (maze[row - 1,col] != 'E')
                    maze[row - 1,col] = 'U';

                FindPath(maze, row - 1, col, visited, path + 'U');
            }
            if (IsSafe(maze, row, col + 1, visited))
            {
                if (maze[row,col + 1] != 'E')
                    maze[row,col + 1] = 'R';

                FindPath(maze, row, col + 1, visited, path + 'R');
            }
            if (IsSafe(maze, row, col-1, visited))
            {
                if (maze[row,col - 1] != 'E')
                    maze[row,col - 1] = 'L';

                FindPath(maze, row, col-1, visited, path + 'L');
            }

            visited[row, col] = false;
            maze[row,col] = '-';

        }
        private static bool IsSafe(char[,] maze,int row,int col,bool[,] visited)
        {
            if (row < 0 || col < 0 || row >= maze.GetLength(0) || col >= maze.GetLength(1))
            {
                return false;
            }
            if (maze[row,col] == '*'|| visited[row,col])
            {
                return false;
            }
            return true;
        }

        private static void Print(char[,] maze)
        {
            for (int row = 0; row < maze.GetLength(0); row++)
            {
                for (int col = 0; col < maze.GetLength(1); col++)
                {
                    Console.Write(maze[row,col]);
                }
                Console.WriteLine();
            }
            Console.WriteLine();
        }
    }
}
