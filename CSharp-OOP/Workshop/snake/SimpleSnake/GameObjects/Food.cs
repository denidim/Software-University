namespace SimpleSnake.GameObjects
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public abstract class Food : Point
    {
        private Random random;
        private Wall wall;
        private char foodSymbol;

        protected Food(Wall wall,char foodSymbol,int points) : base(wall.LeftX,wall.TopY)
        {
            this.wall = wall;
            this.FoodPoints = points;
            this.foodSymbol = foodSymbol;
            this.random = new Random();
        }

        public int FoodPoints { get; private set; }

        public bool IsFoodPoint(Point snake)
        {
            return snake.TopY == this.TopY &&
                snake.LeftX == this.LeftX;
        }

        internal void SetRandomPosition(Queue<Point> snakeElements)
        {
            this.LeftX = random.Next(1, wall.LeftX - 1);
            this.TopY = random.Next(1, wall.TopY - 1);

            bool isPointOfSnake = snakeElements.Any(x => x.LeftX == this.LeftX && x.TopY == this.TopY);

            while (isPointOfSnake)
            {
                this.LeftX = random.Next(1, wall.LeftX - 1);
                this.TopY = random.Next(1, wall.TopY - 1);

                isPointOfSnake = snakeElements.Any(x => x.LeftX == this.LeftX && x.TopY == this.TopY);
            }
            Console.BackgroundColor = ConsoleColor.Red;//commnet this line for macOS
            this.Draw(foodSymbol);
            Console.BackgroundColor = ConsoleColor.White;//comment this line for macOS
        }

    }
}
