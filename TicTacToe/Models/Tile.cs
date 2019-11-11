using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe.Models
{
    public class Tile
    {
        public SignEnum? Sign { get; set; } = null;
        public string Text { 
            get 
            {
                if(Sign == SignEnum.O)
                {
                    return "O";
                }
                if(Sign == SignEnum.X)
                {
                    return "X";
                }
                return "";
            } 
        }
    }
}
