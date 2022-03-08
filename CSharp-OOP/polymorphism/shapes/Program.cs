using System;
using System.Text;

namespace Shapes
{
    public abstract class Shape
    {
        public  abstract double CalculatePerimeter();

        public abstract double CalculateArea();

        public virtual string Draw()
        {
            return "Drawing ";
        }
    }

    public class Rectangle : Shape
    {
        private double height;
        private double width;

        public Rectangle(double height, double width)
        {
            Height = height;
            Width = width;
        }

        public double Height { get => height; set => height = value; }
        public double Width { get => width; set => width = value; }


        public override double CalculateArea()
        {
            return this.Height * this.Width;
        }

        public override double CalculatePerimeter()
        {
            return 2 * (this.Height + this.Width);
        }

        public override string Draw()
        {
            return base.Draw() + this.GetType().Name;
        }

    }

    public class Circle : Shape
    {
        private double radius;

        public double Radius { get => radius; set => radius = value; }

        public Circle(int radius)
        {
            Radius = radius;
        }

        public override double CalculateArea()
        {
            return Math.PI * radius * radius;
        }

        public override double CalculatePerimeter()
        {
            return 2 * Math.PI * radius;
        }

        public override string Draw()
        {
            return base.Draw() + this.GetType().Name;
        }
    }

    public class StartUp
    {
        static void Main(string[] args)
        {
        }
    }
}
