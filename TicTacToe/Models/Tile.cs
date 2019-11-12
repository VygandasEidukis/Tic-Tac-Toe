using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace TicTacToe.Models
{
    public class Tile
    {
        public Button button { get; set; }
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
