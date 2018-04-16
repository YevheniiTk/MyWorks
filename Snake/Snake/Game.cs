namespace Snake
{
    public partial class Game
    {
        public Game(
                    int windowHeigth,
                    int windowWidth,
                    int snakeStartPositionX,
                    int snakeStartPositionY,
                    char wallSymbol,
                    char snakeSymbol,
                    decimal speed)
        {
            this.WindowHeigth = windowHeigth;
            this.WindowWidth = windowWidth;
            this.SnakeStartPositionX = snakeStartPositionX;
            this.SnakeStartPositionY = snakeStartPositionY;
            this.WallSymbol = wallSymbol;
            this.SnakeSymbol = snakeSymbol;
            this.Speed = speed;
        }
        
        public virtual void AddSpeed()
        {
            this.Speed *= 0.925m;
        }
    }
    
    public partial class Game
    {
        public int WindowHeigth { get; private set; }
        
        public int WindowWidth { get; private set; }
        
        public int SnakeStartPositionX { get; private set; }
        
        public int SnakeStartPositionY { get; private set; }
        
        public char WallSymbol { get; private set; }
        
        public char SnakeSymbol { get; private set; }
        
        public decimal Speed { get; private set; }
    }
}
