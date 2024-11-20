using System;

namespace ShapeExample
{
    // Base class for all shapes
    abstract class Shape
    {
        public abstract int GetArea();
    }

    // Rectangle class
    class Rectangle : Shape
    {
        public int Width { get; set; }
        public int Height { get; set; }

        public override int GetArea()
        {
            return Width * Height;
        }
    }

    // Square class
    class Square : Shape
    {
        private int _side;

        public int Side
        {
            get { return _side; }
            set { _side = value; }
        }

        public override int GetArea()
        {
            return _side * _side;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            // Using Rectangle
            Rectangle rect = new Rectangle();
            rect.Width = 5;
            rect.Height = 10;
            Console.WriteLine($"Rectangle Area: {rect.GetArea()}"); // Outputs 50

            // Using Square
            Square square = new Square();
            square.Side = 5;
            Console.WriteLine($"Square Area: {square.GetArea()}"); // Outputs 25

            Console.ReadKey();
        }
    }
}
