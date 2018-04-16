namespace Snake
{
    public class Wall : Figure
    {
        public Wall(int windowHeigth, int windowWidth, char sym)
        {
            for (int i = 1; i <= windowHeigth; i++)
            {
                var p = new Point(1, i, sym);
                this.pointsList.Add(p);
                p = new Point(windowWidth, i, sym);
                this.pointsList.Add(p);
            }

            for (int i = 1; i <= windowWidth; i++)
            {
                var p = new Point(i, 0, sym);
                this.pointsList.Add(p);
                p = new Point(i, windowHeigth, sym);
                this.pointsList.Add(p);
            }
        }
    }
}
