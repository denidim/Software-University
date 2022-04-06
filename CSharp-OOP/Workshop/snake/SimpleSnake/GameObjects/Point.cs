using System;
namespace SimpleSnake.GameObjects
{
    public class Point
    {
        public int LeftX { get; set; }
        public int TopY { get; set; }

        public void Draw(char symbol)
        {
            Console.SetCursorPosition(this.LeftX, this.TopY);
            Console.WriteLine(symbol);
        }

        public void Draw(int leftX,int topY,char symbol)
        {
            Console.SetCursorPosition(this.LeftX, this.TopY);
            Console.WriteLine(symbol);
        }

        public Point(int leftX, int topY)
        {
            LeftX = leftX;
            TopY = topY;
        }
    }
}
