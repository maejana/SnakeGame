using System.IO;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using SnakeGame.Controllers;
using SnakeGame.Models;

namespace SnakeGame;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
///
public partial class MainWindow : Window
{

    private GameController gameController;
    public MainWindow()
    {
        InitializeComponent();
        gameController = new GameController(this);
        gameController.StartGame();
        this.KeyDown += OnKeyDown;
        this.Loaded += (s, e) => this.Focus();

    }

    public void DrawGame()
    {
        GameCanvas.Children.Clear();

        foreach (Point p in gameController.Snake.Body)
        {
            Rectangle rect = new Rectangle
            {
                Width = 20,
                Height = 20,
                Fill = Brushes.Green
            };
            Canvas.SetLeft(rect, p.X * 20);
            Canvas.SetTop(rect, p.Y * 20);
            GameCanvas.Children.Add(rect);
        }

        Point foodPosition = gameController.Food.GetFoodPosition();
        Rectangle foodRect = new Rectangle
        {
            Width = 20,
            Height = 20,
            Fill = Brushes.Red
        };
        Canvas.SetLeft(foodRect, foodPosition.X * 20);
        Canvas.SetTop(foodRect, foodPosition.Y * 20);
        GameCanvas.Children.Add(foodRect);

        PointsTextBlock.Text = $"Points: {gameController.Points}";
    }

    private void OnKeyDown(object sender, KeyEventArgs e)
    {
        var snake = gameController.Snake;
        switch(e.Key)
        {
            case Key.Up when snake.CurrentDirection != Direction.Down:
                snake.CurrentDirection = Direction.Up;
                break; 
            case Key.Down when snake.CurrentDirection != Direction.Up:
                snake.CurrentDirection = Direction.Down;
                break;
            case Key.Left when snake.CurrentDirection != Direction.Right:
                snake.CurrentDirection = Direction.Left;
                break; 
            case Key.Right when snake.CurrentDirection != Direction.Left:
                snake.CurrentDirection = Direction.Right;
                break;
        }
    }
}