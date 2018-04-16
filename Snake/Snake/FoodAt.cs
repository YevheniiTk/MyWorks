namespace Snake
{
    public class FoodAt : Food
    {
        public FoodAt(int windowWidth, int windowHeigth)
            : base(windowWidth, windowHeigth, symbolForFood: '@')
        {
        }
    }
}
