using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe.Models
{
    public class GameMap
    {
        public int Size { get; set; } = 3;
        public string Name { get; set; } = "3x3";
        public List<Tile> Tiles { get; set; }

        public GameMap()
        {
            Tiles = new List<Tile>();
        }

        public void GenerateMap()
        {
            for(int i = 0; i < Size*Size; i++)
            {
                Tiles.Add(new Tile());
            }
        }
        public override string ToString()
        {
            return Name;
        }
    }
}
