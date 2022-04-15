using System.Linq;
using Moq;
using NUnit.Framework;
using TicTakToeVsAI;
using Index = TicTakToeVsAI.Index;

namespace TicTacToeTests
{
    [TestFixture]
    public class TicTacToeUnitTest
    {
        [Test]
        public void PlayShouldReturnValue()
        {
            var player = new Mock<IPlayer>();

            player.Setup(x => x.Play(It.IsAny<Board>(), It.IsAny<Symbol>()))
                .Returns((Board x) => x.GetEmptyPositions().First());
            
            var game = new TicTacToeGame(player.Object, player.Object);
        }

        [Test]
        public void PlayShouldReturncorrectWinner()
        {
            int player1CurrentCol = 0, player2CurrentCol = 0;
            var player1 = new Mock<IPlayer>();
            player1.Setup(x => x.Play(It.IsAny<Board>(), It.IsAny<Symbol>()))
                .Returns((Board x,Symbol s) => new Index(0, player1CurrentCol++));

            var player2 = new Mock<IPlayer>();
            player2.Setup(x => x.Play(It.IsAny<Board>(), It.IsAny<Symbol>()))
                .Returns((Board x, Symbol s) => new Index(2, player2CurrentCol++));

            var game = new TicTacToeGame(player1.Object, player2.Object);

            var winner = game.Play();

            Assert.AreEqual(Symbol.X, winner);
        }
        //todo more mocking
    }
}
