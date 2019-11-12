﻿using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicTacToe.Models;

namespace TicTacToe.ViewModels
{
    class SelectionViewModel : Screen
    {
        #region PROPS
        private BindableCollection<GameMap> _MapSizes;
        public BindableCollection<GameMap> MapSizes
        {
            get { return _MapSizes; }
            set 
            { 
                _MapSizes = value;
                SelectedMapSize = MapSizes[0];
                NotifyOfPropertyChange(() => MapSizes);
            }
        }
        private GameMap _SelectedMapSize;
        public GameMap SelectedMapSize
        {
            get { return _SelectedMapSize; }
            set 
            { 
                _SelectedMapSize = value;
                if ((Parent as MainViewModel) != null)
                    (Parent as MainViewModel).game.Map = value;
                NotifyOfPropertyChange(() => SelectedMapSize);
            }
        }
        public Player player 
        { 
            get 
            { 
                return (Parent as MainViewModel).game.Players[0]; 
            }
            set 
            { 
                (Parent as MainViewModel).game.Players[0] = value; 
                if(value.Sign == SignEnum.X)
                {
                    (Parent as MainViewModel).game.Players[1].Sign = SignEnum.O;
                }
                else
                {
                    (Parent as MainViewModel).game.Players[1].Sign = SignEnum.X;
                }
            } 
        }
        #endregion
        public SelectionViewModel()
        {
            MapSizes = new BindableCollection<GameMap>()
            {
                {
                    new GameMap(){Name="3x3", Size = 3}
                },
                {
                    new GameMap(){Name="4x4", Size = 4}
                },
                {
                    new GameMap(){Name="5x5", Size = 5}
                }
            };
        }

        public void FormLoaded()
        {
            (Parent as MainViewModel).game = new Game();
        }

        public void XChoice()
        {
            player.Sign = SignEnum.X;
        }

        public void OChoice()
        {
            player.Sign = SignEnum.O;
        }

        public void Choose()
        {
            if(player != null)
            {
                SaveSettings();
                (Parent as MainViewModel).ChangeViewToGame();
            }
        }

        private void SaveSettings()
        {
            if(player.Sign == SignEnum.O)
            {
                (Parent as MainViewModel).game.Players[1].Sign = SignEnum.X;
            }else
            {
                (Parent as MainViewModel).game.Players[1].Sign = SignEnum.O;
            }
            (Parent as MainViewModel).game.Map = SelectedMapSize;
        }

    }
}
