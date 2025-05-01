using System.Windows;
using System.Windows.Threading;
using SnakeGame.Models;

namespace SnakeGame.Controllers
{
    /// <summary>
    /// Class for the Controllers of the Game
    /// </summary>
    public class GameController
    {
        private readonly DispatcherTimer gameTimer;
        public Snake Snake { get; private set; }
        private readonly MainWindow mainWindow;
        public Food Food { get; private set; }

        public int Points { get; private set; } = 0; 
        
    

        /// <summary>
        /// Controls the game.
        /// </summary>
        public GameController(MainWindow mainWindow)
        {
            this.mainWindow = mainWindow;
            gameTimer = new DispatcherTimer();
            gameTimer.Interval = TimeSpan.FromMilliseconds(150);
            gameTimer.Tick += GameLoop;

            Food = new Food(null);
            Snake = new Snake(this, Food);
            Food.snake = Snake; 

        }

        /// <summary>
        /// Starts the game.
        /// </summary>
        public void StartGame()
        {
            gameTimer.Start();
        }

        /// <summary>
        /// Stops the game.
        /// </summary>
        public void StopGame()
        {
            gameTimer.Stop();
        }

        /// <summary>
        /// Method to handle events for the Dispatchertimer.
        /// </summary>
        /// <param name="sender">source of the event</param>
        /// <param name="e">Contains the event data for the DispatcherTimer.Tick</param>
        private void GameLoop(object sender, EventArgs e)
        {
            Snake.MoveSnake();
            Food.CheckCollision();
            CheckGameOver();
            mainWindow.DrawGame();
        }

        /// <summary>
        /// Checks if the game is over.
        /// </summary>
        private void CheckGameOver()
        {
            var head = Snake.Body.First.Value;

            if (head.X < 0 || head.Y < 0 || head.X >= 40 || head.Y >= 40)
            {
                StopGame();
                MessageBox.Show("Game Over!");
            }

            if (Snake.Body.Skip(1).Contains(head))
            {
                StopGame();
                MessageBox.Show("Game Over!");
            }
        }
        public void IncrementPoints()
        {
            Points++;
        }
    }
}