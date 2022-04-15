using System;
using System.Collections.Generic;

namespace TicTakToeVsAI.Players
{
    public class AIPlayer : IPlayer
    {
        public AIPlayer()
        {
            this.WinnerLogic = new GameWinnerLogic();
        }

        public GameWinnerLogic WinnerLogic { get; }

        public Index Play(Board board, Symbol symbol)
        {
            Index bestMove = null;

            int bestMoveValue = -1000;

           IEnumerable<Index> moves = board.GetEmptyPositions();

            foreach (Index index in moves)
            {
                board.PlaceSymbol(index,symbol);

                var value = MinMax(board, symbol, symbol == Symbol.X ? Symbol.O : Symbol.X);

                board.PlaceSymbol(index,Symbol.None);

                if (value > bestMoveValue)
                {
                    bestMove = index;

                    bestMoveValue = value;
                }
            }

            return bestMove;
        }

        //recursion
        private int MinMax(Board board, Symbol player, Symbol currPlayer)
        {
            //end
            if (this.WinnerLogic.IsGameOver(board))
            {
                var winner = this.WinnerLogic.GetWinner(board);

                if (winner == player) return 1;

                else if (winner == Symbol.None) return 0;

                else return -1;
            }

            var bestvalue = player == currPlayer ? -100 : 100;

            var options = board.GetEmptyPositions();

            foreach (var option in options)
            {
                board.PlaceSymbol(option,currPlayer);

                var value = MinMax(board, player, currPlayer == Symbol.O ? Symbol.X : Symbol.O);

                board.PlaceSymbol(option, Symbol.None);

                bestvalue =
                    currPlayer == player ?
                    Math.Max(bestvalue, value) :
                    Math.Min(bestvalue, value);
            }

            return bestvalue;
        }
    }
}
