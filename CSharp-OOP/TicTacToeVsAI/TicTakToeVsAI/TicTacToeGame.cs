

namespace TicTakToeVsAI
{
    using Players;

    public class TicTacToeGame
    {
        private ConsolePlayer consolePlayer;

        public TicTacToeGame(IPlayer firstPlayer,IPlayer secondPlayer)
        {
            FirstPlayer = firstPlayer;
            SecondPlayer = secondPlayer;
            this.WinnerLogic = new GameWinnerLogic();
        }

        public TicTacToeGame(ConsolePlayer consolePlayer)
        {
            this.consolePlayer = consolePlayer;
        }

        public IPlayer FirstPlayer { get; }

        public IPlayer SecondPlayer { get; }

        public GameWinnerLogic WinnerLogic { get; }

        public GameResult Play()
        {
            Board board = new Board();

            IPlayer currPlayer = this.FirstPlayer;

            Symbol symbol = Symbol.X;

            while (!this.WinnerLogic.IsGameOver(board))
            {
                //Play round
                var move = currPlayer.Play(board,symbol);

                board.PlaceSymbol(move, symbol);

                if (currPlayer == this.FirstPlayer)
                {
                    currPlayer = this.SecondPlayer;

                    symbol = Symbol.O;
                }
                else
                {
                    currPlayer = this.FirstPlayer;

                    symbol = Symbol.X;
                }
            }

            var winner = this.WinnerLogic.GetWinner(board);

            return new GameResult(winner, board);
        }

        
    }
}
