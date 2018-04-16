namespace Snake
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    
    public partial class Snake : Figure
    {
        private Direction direction;
        
        private Point head;
        
        private Point tail;
        
        private int Length { get; set; }
    }
    
    public partial class Snake : Figure
    {
        public Snake(Point tail, Direction direction)
        {
            this.Length = 5;
            this.direction = direction;
            this.pointsList = new List<Point>();

            for (int i = this.Length; i > 0; i--)
            {
                Point p = new Point(tail.X, tail.Y, tail.Symbol);
                p.Move(i, direction);
                pointsList.Add(p);
            }
        }
        
        public bool Eat(Food food)
        {
            if (food.PointFood.X == this.head.X && food.PointFood.Y == this.head.Y)
            {
                this.Length++;
                Point p = new Point(this.head.X, this.head.Y, this.head.Symbol);
                pointsList.Add(p);
       
                return true;
            }
            else
            {
                return false;
            }
        }
        
        public Point GetNextPoint()
        {
            Point head = pointsList.Last();
            Point nextPoint = new Point(head.X, head.Y, head.Symbol);
            nextPoint.Move(1, this.direction);
            return nextPoint;
        }
        
        public void HandleKey(ConsoleKey key)
        {
            if (key == ConsoleKey.LeftArrow && this.direction != Direction.Right)
            {
                this.direction = Direction.Left;
            }
            else if (key == ConsoleKey.RightArrow && this.direction != Direction.Left)
            {
                this.direction = Direction.Right;
            }
            else if (key == ConsoleKey.DownArrow && this.direction != Direction.Up)
            {
                this.direction = Direction.Down;
            }
            else if (key == ConsoleKey.UpArrow && this.direction != Direction.Down)
            {
                this.direction = Direction.Up;
            }
        }
        
        public bool DidSnakeHitWall(Snake snake, int windowWidth, int windowHeigth)
        {
            if (snake.head.X == 1 || snake.head.X == windowWidth
             || snake.head.Y == 0 || snake.head.Y == windowHeigth)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        
        internal void MoveSnake()
        {
            this.tail = pointsList.First();
            this.pointsList.Remove(this.tail);
            this.head = this.GetNextPoint();
            this.pointsList.Add(this.head);
            
            this.tail.Clear();
            this.head.Draw();
        }
    }
}
