using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

namespace TicTacToe.Models
{
    public class Game
    {
        public delegate void GameWon(SignEnum winner);
        public GameWon WinnerDelegate;

        public List<Player> Players { get; set; }
        public GameMap Map { get; set; }

        private Player _currentPlayerTurn;

        public Player CurrentPlayerTurn
        {
            get => _currentPlayerTurn;
            set
            {
                if(_currentPlayerTurn == null)
                {
                    _currentPlayerTurn = Players[0].Sign == SignEnum.X ? Players[0] : Players[1];
                }else
                {
                    _currentPlayerTurn = _currentPlayerTurn == Players[0] ? Players[1] : Players[0];
                }
            }
        }


        public Game()
        {
            Players = new List<Player> {new Player(), new Player()};
            Map = new GameMap();
            Map.GenerateMap();
        }

        public void TileClicked(object sender, object e)
        {
            if((sender as Button) == null)
                throw new Exception("Wrong object");

            if(CurrentPlayerTurn == null)
                CurrentPlayerTurn = new Player();

            if (((Button) sender)?.Content as string != "") return;

            FindTile((Button) sender).Update(CurrentPlayerTurn.Sign);
            if(GameLogic.CheckWin(Map, CurrentPlayerTurn.Sign))
            {
                WinnerDelegate?.Invoke(CurrentPlayerTurn.Sign);
            }
            CurrentPlayerTurn = new Player();
        }

        public Tile FindTile(Button button)
        {
            for(var i = 0; i < Map.Size; i++)
            {
                foreach (var tile in Map.Tiles[i])
                {
                    if(tile.Button == button)
                    {
                        return tile;
                    }
                }
            }
            return null;
        }
    }
}
