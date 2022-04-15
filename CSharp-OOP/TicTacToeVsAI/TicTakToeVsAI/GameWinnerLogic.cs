using System;
namespace TicTakToeVsAI
{
    public class GameWinnerLogic
    {
        public bool IsGameOver(Board board)
        {
            for (int row = 0; row < board.Rows; row++)
            {
                if (board.GetRowSymbol(row) != Symbol.None)
                {
                    return true;
                }
            }

            for (int col = 0; col < board.Cols; col++)
            {
                if (board.GetColSymbol(col) != Symbol.None)
                {
                    return true;
                }
            }

            if (board.GetDiagonalSymbolTL() != Symbol.None)
            {
                return true;
            }

            if (board.GetDiagonalSymbolTR() != Symbol.None)
            {
                return true;
            }

            return board.IsFull();
        }

        public Symbol GetWinner(Board board)
        {
            for (int row = 0; row < board.Rows; row++)
            {
                var winner = board.GetRowSymbol(row);

                if (winner != Symbol.None)
                {
                    return winner;
                }
            }

            for (int col = 0; col < board.Cols; col++)
            {
                var winner = board.GetColSymbol(col);

                if (winner != Symbol.None)
                {
                    return winner;
                }
            }

            var diagonal1 = board.GetDiagonalSymbolTL();

            if (diagonal1 != Symbol.None)
            {
                return diagonal1;
            }

            var diagonal2 = board.GetDiagonalSymbolTR();

            if (diagonal2 != Symbol.None)
            {
                return diagonal2;
            }

            return Symbol.None;
        }
    }
}
