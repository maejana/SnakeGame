using System.Windows;

namespace SnakeGame.Models
{
    public class Food
    {
        private Point food;
        private Random rand = new Random();
        public Snake snake;
        public int growthQueue = 0;

        public Food(Snake snake)
        {
            this.snake = snake;
            PlaceFood();
        }

        private void PlaceFood()
        {
            food = new Point(rand.Next(0, 25), rand.Next(0, 25));
        }

        public void CheckCollision()
        {
            if (snake.Body.First.Value == food)
            {
                growthQueue++;
                PlaceFood();
            }
        }

        public Point GetFoodPosition()
        {
            return food;
        }
    }
}