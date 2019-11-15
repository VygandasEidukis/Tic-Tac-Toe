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
        private Game _Game;

        public Game game
        {
            get => _Game;
            set 
            { 
                _Game = value;
                NotifyOfPropertyChange(()=>game);
            }
        }

        public GameViewModel(Game game)
        {
            this.game = game;
            game.WinnerDelegate += AnnounceWinner;
        }

        public void AnnounceWinner(SignEnum winner)
        {
            MessageBox.Show($"You Won {winner}", "Winner", MessageBoxButton.OK, MessageBoxImage.Information);
            (Parent as MainViewModel)?.ActivateItem(new SelectionViewModel());
        }
    }
}
