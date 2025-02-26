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
        gameController = new GameController();
        gameController.StartGame();
    }
}