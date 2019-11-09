﻿using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe.ViewModels
{
    class MainViewModel : Conductor<object>
    {
        public MainViewModel()
        {
            ActivateItem(new SelectionViewModel());
        }
    }
}
