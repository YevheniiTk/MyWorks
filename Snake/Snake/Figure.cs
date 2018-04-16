namespace Snake
{
    using System.Collections.Generic;
    
    public abstract class Figure
    {
        protected List<Point> pointsList = new List<Point>();
        
        public virtual void Draw()
        {
            foreach (Point p in this.pointsList)
            {
                p.Draw();
            }
        }
    }
}