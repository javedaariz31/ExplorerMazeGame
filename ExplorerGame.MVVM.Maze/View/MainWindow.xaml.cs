using ExplorerGame.MVVM.Maze.ViewModel;
using System.Windows;

namespace ExplorerGame.MVVM.Maze
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            // Create the View Model.
            MazeGameViewModel viewModel = new MazeGameViewModel();
            DataContext = viewModel;
        }

    }
}
