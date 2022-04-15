using System.Linq;
using NUnit.Framework;
using TicTakToeVsAI;

namespace TicTacToeTests
{
    [TestFixture]
    public class BoardTests
    {
        [Test]
        public void IsFullSouldReturnTrueForFullBoard()
        {
            Board board = new Board(3);

            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    Assert.IsFalse(board.IsFull());
                    board.PlaceSymbol(new Index(i, j),Symbol.X);
                }
            }
            Assert.IsTrue(board.IsFull());
        }

        [TestCase(Symbol.X)]
        [TestCase(Symbol.O)]
        public void GetRolSymbolShouldWork(Symbol symbol)
        {
            Board board = new Board(4);

            for (int i = 0; i < board.Cols; i++)
            {
                Assert.AreEqual(Symbol.None, board.GetRowSymbol(2));
                board.PlaceSymbol(new Index(2,i), symbol);
            }
            Assert.AreEqual(symbol, board.GetRowSymbol(2));
        }

        [TestCase(Symbol.X)]
        [TestCase(Symbol.O)]
        public void GetColSymbolShouldWork(Symbol symbol)
        {
            Board board = new Board(5);

            for (int i = 0; i < board.Rows; i++)
            {
                Assert.AreEqual(Symbol.None, board.GetRowSymbol(2));
                board.PlaceSymbol(new Index(i, 1), symbol);
            }
            Assert.AreEqual(symbol, board.GetColSymbol(1));
        }

        //todo more tests
        //diagonals..

        [Test]
        public void GetEmptyPositionsShouldReturnCorectPositions()
        {
            Board board = new Board(3);
            var positions = board.GetEmptyPositions();
            Assert.AreEqual(3 * 3, positions.Count());
        }

        [Test]
        public void GetEmptyPositionsShouldReturnAllPositions()
        {
            Board board = new Board(4);
            board.PlaceSymbol(new Index(1, 1), Symbol.X);
            board.PlaceSymbol(new Index(2, 2), Symbol.O);
            var positions = board.GetEmptyPositions();
            Assert.AreEqual(4 * 4-2, positions.Count());

        }
    }
}
