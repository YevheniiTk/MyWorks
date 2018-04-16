namespace Snake
{
    using System;
    
    class Program
    {
        private static void Main(string[] args)
        {
            int windowHeigth = 29;
            int windowWidth = 70;
            int snakeStartPositionX = 10;
            int snakeStartPositionY = 10;
            char wallSymbol = 'X';
            char snakeSymbol = 'O';
            decimal speed = 150m;

            var isGameOn = true;

            var game = new Game(windowHeigth, 
                                windowWidth,
                                snakeStartPositionX,
                                snakeStartPositionY,
                                wallSymbol,
                                snakeSymbol,
                                speed
                                );

            int foodPositionX = 17;
            int foodPositionY = 20;

            Food food = new FoodAt(foodPositionX, foodPositionY);

            var wall = new Wall(game.WindowHeigth, 
                                game.WindowWidth, 
                                game.WallSymbol
                                );

            var snake = new Snake(
                                 new Point(
                                  game.SnakeStartPositionX,
                                  game.SnakeStartPositionY,
                                  game.SnakeSymbol),
                                  Direction.Right
                                  );

            Console.WindowHeight = game.WindowHeigth + 1;
            Console.WindowWidth = game.WindowWidth + 1;
            Console.CursorVisible = false;

            wall.Draw();
            food.Draw();

            ConsoleKey command = ConsoleKey.RightArrow;

            while (isGameOn)
            {
                System.Threading.Thread.Sleep((int)game.Speed);

                if (Console.KeyAvailable)
                {
                    command = Console.ReadKey().Key;
                    snake.HandleKey(command);
                }

                snake.MoveSnake();

                if (snake.Eat(food))
                {
                    game.AddSpeed();
                    food = CreateFood(game);
                    food.Draw();
                }

                var isWallHit = snake.DidSnakeHitWall(snake, game.WindowWidth, game.WindowHeigth);

                if (isWallHit)
                {
                    isGameOn = false;
                    Console.SetCursorPosition(10, 10);
                    Console.WriteLine("The snke hit the wall and died.");
                }
            }

            ContinueTheGameOrNot();
        }
        
        private static Food CreateFood(Game game)
        {
            Random r = new Random();
            if (r.Next(2) == 0)
            {
                return new FoodAt(game.WindowWidth, game.WindowHeigth);
            }
            else
            {
                return new FoodSharp(game.WindowWidth, game.WindowHeigth);
            }
        }
        
        private static void ContinueTheGameOrNot()
        {
            Console.SetCursorPosition(10, 12);
            Console.WriteLine("If you want to play again, press Y.");
            if (Console.ReadKey().Key == ConsoleKey.Y)
            {
                Console.Clear();
                Main(null);
            }
        }
    }
}
