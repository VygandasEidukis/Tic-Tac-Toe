using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicTacToe.Models;

namespace TicTacToe.ViewModels
{
    class MainViewModel : Conductor<object>
    {
        public Game game { get; set; }
        public MainViewModel()
        {
            ActivateItem(new SelectionViewModel());
        }

        public void ChangeViewToGame()
        {
            ActivateItem(new GameViewModel(game));
        }
    }
}
