namespace Snake
{
    public class FoodSharp : Food
    {
        public FoodSharp(int windowWidth, int windowHeigth)
            : base(windowWidth, windowHeigth, symbolForFood: '#')
        {
        }
    }
}