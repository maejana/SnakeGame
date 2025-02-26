using System.Windows.Threading;
using SnakeGame.Models;

namespace SnakeGame.Controllers
{
    public class GameController
    {
        private readonly DispatcherTimer gameTimer;
        public Snake Snake { get; private set; }
        private readonly MainWindow mainWindow;

        /// <summary>
        /// Controls the game.
        /// </summary>
        public GameController(MainWindow mainWindow)
        {
            this.mainWindow = mainWindow;
            gameTimer = new DispatcherTimer();
            gameTimer.Interval = TimeSpan.FromMilliseconds(150);
            gameTimer.Tick += GameLoop;

            Snake = new Snake();
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

        private void GameLoop(object sender, EventArgs e)
        {
            Snake.MoveSnake();
            mainWindow.DrawGame();
        }
    }
}