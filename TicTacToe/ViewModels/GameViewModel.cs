using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using TicTacToe.Models;

namespace TicTacToe.ViewModels
{
    class GameViewModel : Screen
    {
        private Game _game;

        public Game Game
        {
            get => _game;
            set 
            { 
                _game = value;
                NotifyOfPropertyChange(()=>Game);
            }
        }

        public GameViewModel(Game game)
        {
            this.Game = game;
            game.WinnerDelegate += AnnounceWinner;
        }

        public void AnnounceWinner(SignEnum winner)
        {
            MessageBox.Show($"You Won {winner}", "Winner", MessageBoxButton.OK, MessageBoxImage.Information);
            (Parent as MainViewModel)?.ActivateItem(new SelectionViewModel());
        }
    }
}
