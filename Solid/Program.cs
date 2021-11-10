using Solid.SingleResponsibilityPrinciple;

namespace Solid
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            Shape rect = new Rectangle
            {
                Length = 10,
                Width = 5
            };
            System.Console.WriteLine(rect.CalculateArea()); // result: 5 * 10 = 50

            Shape square = new Square
            {
                Edge = 5
            }; 
            System.Console.WriteLine(square.CalculateArea()); // result: 5 * 5 = 25
        }
    }
}