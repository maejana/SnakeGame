
using System.Windows;
using System.Collections.Generic;

namespace SnakeGame.Models
{
    /// <summary>
    /// Represents the snake in the Snake game.
    /// </summary>
    public class Snake
    {
        private Food food;

        /// <summary>
        /// Gets or sets the body of the snake as a linked list of points.
        /// </summary>
        public LinkedList<Point> Body { get; set; } = new LinkedList<Point>();

        /// <summary>
        /// Gets or sets the current direction of the snake.
        /// </summary>
        public Direction CurrentDirection { get; set; } = Direction.Right;

        /// <summary>
        /// Initializes a new instance of the <see cref="Snake"/> class.
        /// </summary>
        public Snake(Food food)
        {
            this.food = food;
            Body.AddFirst(new Point(5, 5));
        }

        /// <summary>
        /// Moves the snake-head in the current direction.
        /// </summary>
        public void MoveSnake()
        {
            Point newHead = this.Body.First.Value;

            switch (this.CurrentDirection)
            {
                case Direction.Up:
                    newHead.Y -= 1;
                    break;
                case Direction.Down:
                    newHead.Y += 1;
                    break;
                case Direction.Left:
                    newHead.X -= 1;
                    break;
                case Direction.Right:
                    newHead.X += 1;
                    break;
            }

            Body.AddFirst(newHead);

            if (food.growthQueue > 0)
            {
                food.growthQueue--;  // Reduce growth queue
            }
            else
            {
                Body.RemoveLast(); // Remove last point (normal movement)
            }
        }
    }
}