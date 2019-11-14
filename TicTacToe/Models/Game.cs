using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace TicTacToe.Models
{
    public class Game
    {
        public delegate void GameWon(SignEnum winner);
        public GameWon _WinnerDelegate;

        public List<Player> Players { get; set; }
        public GameMap Map { get; set; }

        private Player _CurrentPlayerTurn;

        public Player CurrentPlayerTrun
        {
            get { return _CurrentPlayerTurn; }
            set 
            { 
                if(_CurrentPlayerTurn == null)
                {
                    if (Players[0].Sign == SignEnum.X)
                    {
                        _CurrentPlayerTurn = Players[0];
                    }
                    else
                        _CurrentPlayerTurn = Players[1];
                }else
                {
                    if(_CurrentPlayerTurn == Players[0])
                    {
                        _CurrentPlayerTurn = Players[1];
                    }else
                    {
                        _CurrentPlayerTurn = Players[0];
                    }
                }
            }
        }


        public Game()
        {
            Players = new List<Player>();
            Players.Add(new Player()); 
            Players.Add(new Player());
            Map = new GameMap();
            Map.GenerateMap();
            
        }

        public void TileClicked(object sender, RoutedEventArgs e)
        {
            if(CurrentPlayerTrun == null)
                CurrentPlayerTrun = new Player();

            if ((sender as Button).Content == "")
            {
                FindTile(sender as Button).Update(CurrentPlayerTrun.Sign);
                if(GameLogic.CheckWin(Map, CurrentPlayerTrun.Sign))
                {
                    if (_WinnerDelegate != null)
                        _WinnerDelegate.Invoke(CurrentPlayerTrun.Sign);
                }
                CurrentPlayerTrun = new Player();
            }
        }

        public Tile FindTile(Button button)
        {
            for(int i = 0; i < Map.Size; i++)
            {
                foreach (Tile tile in Map.Tiles[i])
                {
                    if(tile.button == button)
                    {
                        return tile;
                    }
                }
            }
            return null;
        }
    }
}
