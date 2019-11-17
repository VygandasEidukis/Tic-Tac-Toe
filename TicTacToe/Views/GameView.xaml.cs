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
            _gvm.Game.Map.GenerateMap();
            int size = _gvm.Game.Map.Size;
            for (var i = 0; i < size; i++)
            {
                var sp = new StackPanel {Orientation = Orientation.Horizontal};
                VerticalPanel.Children.Add(sp);
                for(var x = 0; x < size; x++)
                {
                    _gvm.Game.Map.Tiles[i][x].Button = new Button
                    {
                        Width = 50, Height = 50, Margin = new Thickness(3), Content = ""
                    };
                    _gvm.Game.Map.Tiles[i][x].Button.Click += _gvm.Game.TileClicked;
                    sp.Children.Add(_gvm.Game.Map.Tiles[i][x].Button);
                }
            }
        }
    }
}
