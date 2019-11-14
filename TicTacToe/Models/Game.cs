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
                (sender as Button).Content = CurrentPlayerTrun.Sign;
                CurrentPlayerTrun = new Player();
            }
        }
    }
}
