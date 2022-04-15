using System;
using TicTakToeVsAI.Players;

namespace TicTakToeVsAI
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "TicTacToe 1.0";
            while (true)
            {
                Console.Clear();
                Console.WriteLine("==== TicTacToe 1.0 ====");
                Console.WriteLine("1. Player vs Player");
                Console.WriteLine("2. Player vs Random");
                Console.WriteLine("3. Random vs Player");
                Console.WriteLine("4. Player vs AI");
                Console.WriteLine("5. AI vs Player");
                Console.WriteLine("6. Simulate random vs random");
                Console.WriteLine("7. Simulate AI vs random");
                Console.WriteLine("8. Simulate random vs AI");
                Console.WriteLine("9. Simulate AI vs AI");

                Console.WriteLine("0. EXIT");

                while (true)
                {
                    Console.Write("Plese select game [0-8]: ");
                    var line = Console.ReadLine();
                    if (line == "0")
                    {
                        Environment.Exit(0);
                    }
                    if (line == "1")
                    {
                        PlayGame(new ConsolePlayer(),new ConsolePlayer());
                        break;
                    }
                    else if (line == "2")
                    {
                        PlayGame(new ConsolePlayer(), new RandomPlayer());
                        break;
                    }
                    else if (line == "3")
                    {
                        PlayGame(new RandomPlayer(), new ConsolePlayer());
                        break;
                    }
                    else if (line == "4")
                    {
                        PlayGame(new ConsolePlayer(), new AIPlayer());
                        break;
                    }
                    else if (line == "5")
                    {
                        PlayGame(new AIPlayer(), new ConsolePlayer());
                        break;
                    }
                    else if (line == "6")
                    {
                        Simulate(new RandomPlayer(), new RandomPlayer(),10000);
                        break;
                    }
                    else if (line == "7")
                    {
                        Simulate(new AIPlayer(), new RandomPlayer(), 10);
                        break;
                    }
                    else if (line == "8")
                    {
                        Simulate(new RandomPlayer(), new AIPlayer(), 10);
                        break;
                    }
                    else if (line == "9")
                    {
                        Simulate(new AIPlayer(), new AIPlayer(), 10);
                        break;
                    }
                }

                Console.WriteLine("Pres [enter] to continue");
                Console.ReadLine();
            }
        }

        static void Simulate(IPlayer player1, IPlayer player2,int count)
        {
            int x = 0, o = 0, drow = 0;
            int firstWinner = 0;
            int secondWinner = 0;

            var first = player1;
            var second = player2;

            for (int i = 0; i < count; i++)
            {
                var game = new TicTacToeGame(first, second);


                var result = game.Play();
                if (result.Winner == Symbol.X && first == player1) firstWinner++;
                if (result.Winner == Symbol.O && first == player1) secondWinner++;
                if (result.Winner == Symbol.X && first == player2) secondWinner++;
                if (result.Winner == Symbol.O && first == player2) firstWinner++;
                if (result.Winner == Symbol.X) x++;
                if (result.Winner == Symbol.O) o++;
                if (result.Winner == Symbol.None) drow++;
                (first, second) = (second, first);
            }

            Console.WriteLine("Games played: " + count);
            Console.WriteLine("Games won by X: " + x);
            Console.WriteLine("Games won by O: " + o);
            Console.WriteLine("Draw games: " + drow);
            Console.WriteLine(player1.GetType().Name + " won games: " + firstWinner);
            Console.WriteLine(player2.GetType().Name + " won games: " + secondWinner);
        }

        static void PlayGame(IPlayer player1, IPlayer player2)
        {
            var game = new TicTacToeGame(
                    player1,
                    player2);


            var result = game.Play();

            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Game over!");
            Console.WriteLine();
            if (result.Winner == Symbol.None)
            {
                Console.WriteLine($"Winner: Draw");
            }
            else
            {
                Console.WriteLine($"Winner: {result.Winner}");
            }
            Console.WriteLine();
            Console.WriteLine(result.Board.ToString());
            Console.ResetColor();
        }
    }
}
