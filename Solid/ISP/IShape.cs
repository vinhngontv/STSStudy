namespace Solid.ISP
{
    public interface IShape
    {
        double CalculateArea();
        void Draw();
    }
    
    public interface IRectangle
    {
        int Length { get; set; }
        int Width { get; set; }
    }
    
    public class RectangleShape : IShape, IRectangle
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
}