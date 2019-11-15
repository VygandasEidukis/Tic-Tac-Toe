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
        public Button Button { get; set; }

        public SignEnum? Sign { get; set; }

        public string Text { 
            get 
            {
                switch (Sign)
                {
                    case SignEnum.O:
                        return "O";
                    case SignEnum.X:
                        return "X";
                    default:
                        return "";
                }
            } 
        }

        public void Update(SignEnum? enu)
        {
            Sign = enu;
            Button.Content = enu;
        }
    }
}
