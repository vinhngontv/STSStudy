namespace Solid.LSP
{
    public class Shape
    {
        
    }
    
    public class Rectangle
    {
        public int Length { get; set; }
        public int Width { get; set; }
    
        public virtual void SetLength(int length)
        {
            this.Length = length;
        }
        public virtual void SetWidth(int width)
        {
            this.Width = width;
        }
        
        public int CalculateArea()
        {
            return this.Length * this.Width;
        }
    }
    
    public class Square : Rectangle
    {
        public override void SetLength(int length)
        {
            this.Length = length;
            this.Width = length;
        }
    
        public override void SetWidth(int width)
        {
            this.Length = width;
            this.Width = width;
        }
    }
}