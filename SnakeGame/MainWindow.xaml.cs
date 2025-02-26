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
    }
}