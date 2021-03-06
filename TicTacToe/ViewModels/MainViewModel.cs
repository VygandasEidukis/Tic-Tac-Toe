﻿using Caliburn.Micro;
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
        public Game Game { get; set; }

        public MainViewModel()
        {
            ActivateItem(new SelectionViewModel());
        }

        public sealed override void ActivateItem(object item)
        {
            base.ActivateItem(item);
        }

        public void ChangeViewToGame()
        {
            ActivateItem(new GameViewModel(Game));
        }
    }
}
