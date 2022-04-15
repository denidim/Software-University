using System;
using System.Collections.Generic;
using System.Text;

namespace TicTakToeVsAI
{

    public class Board:IBoard
    {
        private Symbol[,] board;

        public Board()
            : this(3)
        {

        }

        public Board(int size)
        {
            Rows = size;
            Cols = size;
            board = new Symbol[size, size];
        }

        public int Rows { get; }

        public int Cols { get; }

        public Symbol[,] BoardState => this.board;

        public Symbol GetRowSymbol(int row)
        {
            var symbol = this.board[row, 0];

            if (symbol == Symbol.None)
            {
                return Symbol.None;
            }

            for (int col =1 ; col < this.Cols; col++)
            {
                if (this.board[row, col] != symbol)
                {
                    return Symbol.None;
                }
            }

            return symbol;
        }

        public Symbol GetColSymbol(int col)
        {
            var symbol = this.board[0, col];

            if (symbol == Symbol.None)
            {
                return Symbol.None;
            }

            for (int row = 1; row < this.Rows; row++)
            {
                if (this.board[row, col] != symbol)
                {
                    return Symbol.None;
                }
            }

            return symbol;
        }

        public Symbol GetDiagonalSymbolTL()
        {
            var symbol = this.board[0, 0];

            if (symbol == Symbol.None)
            {
                return Symbol.None;
            }

            for (int i = 1; i < this.Rows; i++)
            {
                if (this.board[i, i] != symbol)
                {
                    return Symbol.None;
                }
            }

            return symbol;
        }

        public Symbol GetDiagonalSymbolTR()
        {
            var symbol = this.board[0, Rows-1];

            if (symbol == Symbol.None)
            {
                return Symbol.None;
            }

            for (int i = 1; i < this.Rows; i++)
            {
                int lastCol = Rows - 1;

                if (this.board[i, lastCol - i] != symbol)
                {
                    return Symbol.None;
                }
            }

            return symbol;
        }

        public IEnumerable<Index> GetEmptyPositions()
        {
            var positions = new List<Index>();

            for (int i = 0; i < this.Rows; i++)
            {
                for (int j = 0; j < this.Cols; j++)
                {
                    if (this.board[i, j] == Symbol.None)
                    {
                        positions.Add(new Index(i, j));
                    }
                }
            }

            return positions;
        }

        public bool IsFull()
        {
            for (int i = 0; i < this.Rows; i++)
            {
                for (int j = 0; j < this.Cols; j++)
                {
                    if (this.board[i, j] == Symbol.None)
                    {
                        return false;
                    }
                }
            }

            return true;
        }

        public void PlaceSymbol(Index index, Symbol symbol)
        {
            if (index.Row < 0 || index.Col < 0 ||
                index.Row >= this.Rows || index.Col >= this.Cols)
            {
                throw new IndexOutOfRangeException();
            }

            this.board[index.Row, index.Col] = symbol;
        }

        public override string ToString()
        {
            var sb = new StringBuilder();

            for (int i = 0; i < this.Rows; i++)
            {
                for (int j = 0; j < this.Cols; j++)
                {
                    if (this.board[i, j] == Symbol.None)
                    {
                        sb.Append('.');
                    }
                    else
                    {
                        sb.Append(board[i, j]);
                    }
                }
                sb.AppendLine();
            }
            return sb.ToString();
        }
    }
}
