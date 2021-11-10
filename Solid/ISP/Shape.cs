namespace Solid.ISP
{
    public interface Shape
    {
        int Length { get; set; }
        int Width { get; set; }
        int Edge { get; set; }
        int Radius { get; set; }
        double CalculateArea();
        void Draw();
    }
    
    public class Rectangle : Shape
    {
        public int Length { get; set; }
        public int Width { get; set; }
        public int Edge { get; set; }
        public int Radius { get; set; }

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
        public int Length { get; set; }
        public int Width { get; set; }
        public int Edge { get; set; }
        public int Radius { get; set; }

        public double CalculateArea()
        {
            return Edge * Edge;
        }

        public void Draw()
        {
            /*Draw Square*/
        }
    }
}