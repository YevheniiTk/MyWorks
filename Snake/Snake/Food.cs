namespace Snake
{
    using System;
    using System.Collections.Generic;

    public abstract class Food : Figure
    {
        public readonly Point PointFood;

        private readonly char symbolForFood;

        private Random random;

        public Food(int windowWidth, int windowHeigth, char symbolForFood)
        {
            this.random = new Random();
            int xRandom = this.random.Next(2, windowWidth);
            int yRandom = this.random.Next(1, windowHeigth);

            this.symbolForFood = symbolForFood;

            this.PointFood = new Point(xRandom, yRandom, this.symbolForFood);
            this.pointsList = new List<Point> { this.PointFood };
        }
    }
}