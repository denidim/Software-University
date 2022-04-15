using System.Collections.Generic;

namespace TicTakToeVsAI
{
    public interface IBoard
    {
        bool IsFull();

        void PlaceSymbol(Index index, Symbol symbol);

        IEnumerable<Index> GetEmptyPositions();

        Symbol GetRowSymbol(int row);

        Symbol GetColSymbol(int col);

        Symbol GetDiagonalSymbolTL();

        Symbol GetDiagonalSymbolTR();

    }
}
