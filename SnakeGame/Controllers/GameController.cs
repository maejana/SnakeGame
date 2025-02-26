using System.Windows.Threading;
using SnakeGame.Models;

namespace SnakeGame.Controllers;

public class GameController
{
    private readonly DispatcherTimer gameTimer;
    private readonly Snake snake;

    
    /// <summary>
    /// Controlls the game.
    /// </summary>
    public GameController()
    {
        gameTimer = new DispatcherTimer();
        gameTimer.Interval = TimeSpan.FromMilliseconds(150);
        gameTimer.Tick += GameLoop;
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
        snake.MoveSnake();
    }
    
}