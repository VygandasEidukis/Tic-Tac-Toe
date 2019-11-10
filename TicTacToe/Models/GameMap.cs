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

        public override string ToString()
        {
            return Name;
        }
    }
}
