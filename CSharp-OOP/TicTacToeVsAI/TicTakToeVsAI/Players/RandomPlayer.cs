using System;
using System.Collections.Generic;
using System.Linq;

namespace TicTakToeVsAI.Players
{
    public class RandomPlayer:IPlayer
    {
        private Random random;

        public RandomPlayer()
        {
            this.random = new Random();
        }

        public Index Play(Board board,Symbol symbol)
        {
            List<Index> availablePositions = board.GetEmptyPositions().ToList();

            return availablePositions[random.Next(0, availablePositions.Count())];
        }
    }
}
