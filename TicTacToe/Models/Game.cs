using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe.Models
{
    public class Game
    {
        public List<Player> Players { get; set; }
        public GameMap Map { get; set; }

        public Game()
        {
            Players = new List<Player>();
            Players.Add(new Player()); 
            Players.Add(new Player());
            Map = new GameMap();
            Map.GenerateMap();
        }
    }
}
