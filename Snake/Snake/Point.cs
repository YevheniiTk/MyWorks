namespace Snake
{
    using System;
    
    public partial class Point
    {
        public readonly char Symbol;
        
        public int X { get; private set; }
        
        public int Y { get; private set; }
    }
    
    public partial class Point
    {
        public Point(int x, int y, char symbol)
        {
            this.X = x;
            this.Y = y;
            this.Symbol = symbol;
        }
        
        public void Draw()
        {
            this.Draw(this.X, this.Y, this.Symbol);
        }
        
        public void Clear()
        {
            this.Draw(this.X, this.Y, ' ');
        }
        
        public void Move(int offset, Direction direction)
        {
            switch (direction)
            {
                case Direction.Right:
                    this.X = this.X + offset;
                    break;
                case Direction.Left:
                    this.X = this.X - offset;
                    break;
                case Direction.Down:
                    this.Y = this.Y + offset;
                    break;
                case Direction.Up:
                    this.Y = this.Y - offset;
                    break;
            }
        }

        private void Draw(int x, int y, char symbol)
        {
            Console.SetCursorPosition(x, y);
            Console.Write(symbol);
            Console.SetCursorPosition(0, 0);
        }
    }
}
