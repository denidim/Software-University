using System;
namespace TicTakToeVsAI
{
    public class GameResult
    {
        public GameResult(Symbol winner, Board board)
        {
            Winner = winner;
            Board = board;
        }

        public Symbol Winner { get; }
        public Board Board { get; }
    }
}
