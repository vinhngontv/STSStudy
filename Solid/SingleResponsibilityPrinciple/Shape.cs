using System.Collections.Generic;

namespace Solid.SingleResponsibilityPrinciple
{
    public interface Shape
    {
        double CalculateArea();
        void Draw();
    }

    public class Rectangle : Shape
    {
        public int Length { get; set; }
        public int Width { get; set; }
        
        public double CalculateArea()
        {
            return Length * Width;
        }

        public void Draw()
        {
            /*Draw Rectangle*/
        }
    }
    
    public class Square : Shape
    {
        public int Edge { get; set; }
        
        public double CalculateArea()
        {
            return Edge * Edge;
        }

        public void Draw()
        {
            /*Draw Square*/
        }
    }
    
    public class Circle : Shape
    {
        public int Radius { get; set; }
        private const double PI = 3.14;
        
        public double CalculateArea()
        {
            return PI * Radius * Radius;
        }

        public void Draw()
        {
            /*Draw circle*/
        }
    }
    
    public static class Drawer
    {
        public static void DrawShapes(IEnumerable<Shape> shapes) {
            foreach (var shape in shapes) {
                shape.Draw();
            }
        }
    }
}