using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using TicTacToe.ViewModels;

namespace TicTacToe.Views
{
    /// <summary>
    /// Interaction logic for GameView.xaml
    /// </summary>
    public partial class GameView : UserControl
    {
        GameViewModel gvm;
        public GameView()
        {
            InitializeComponent();
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            gvm = DataContext as GameViewModel;
            GenerateButtons();
        }

        private void GenerateButtons()
        {
            gvm.game.Map.GenerateMap();
            int size = gvm.game.Map.Size;
            for (int i = 0; i < size; i++)
            {
                StackPanel sp = new StackPanel();
                sp.Orientation = Orientation.Horizontal;
                VerticalPanel.Children.Add(sp);
                for(int x = 0; x < size; x++)
                {
                    gvm.game.Map.Tiles[i][x].button = new Button();
                    gvm.game.Map.Tiles[i][x].button.Width = 50;
                    gvm.game.Map.Tiles[i][x].button.Height = 50;
                    gvm.game.Map.Tiles[i][x].button.Margin = new Thickness(3);
                    gvm.game.Map.Tiles[i][x].button.Content = "";
                    gvm.game.Map.Tiles[i][x].button.Click += gvm.game.TileClicked;
                    sp.Children.Add(gvm.game.Map.Tiles[i][x].button);
                }
            }
        }
    }
}
