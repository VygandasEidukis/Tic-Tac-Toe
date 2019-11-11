using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicTacToe.Models;

namespace TicTacToe.ViewModels
{
    class GameViewModel : Screen
    {
        private Game _Game;

        public Game game
        {
            get { return _Game; }
            set 
            { 
                _Game = value;
                NotifyOfPropertyChange(()=>game);
            }
        }

        public GameViewModel(Game game)
        {
            this.game = game;
        }

        public void TilePressed(object tile)
        {

        }
    }
}
