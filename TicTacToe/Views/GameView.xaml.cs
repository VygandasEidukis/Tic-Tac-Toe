using System.Windows;
using System.Windows.Controls;
using TicTacToe.ViewModels;

namespace TicTacToe.Views
{
    /// <summary>
    /// Interaction logic for GameView.xaml
    /// </summary>
    public partial class GameView : UserControl
    {
        GameViewModel _gvm;
        public GameView()
        {
            InitializeComponent();
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            _gvm = DataContext as GameViewModel;
            GenerateButtons();
        }

        private void GenerateButtons()
        {
            _gvm.game.Map.GenerateMap();
            int size = _gvm.game.Map.Size;
            for (var i = 0; i < size; i++)
            {
                var sp = new StackPanel {Orientation = Orientation.Horizontal};
                VerticalPanel.Children.Add(sp);
                for(var x = 0; x < size; x++)
                {
                    _gvm.game.Map.Tiles[i][x].Button = new Button
                    {
                        Width = 50, Height = 50, Margin = new Thickness(3), Content = ""
                    };
                    _gvm.game.Map.Tiles[i][x].Button.Click += _gvm.game.TileClicked;
                    sp.Children.Add(_gvm.game.Map.Tiles[i][x].Button);
                }
            }
        }
    }
}
