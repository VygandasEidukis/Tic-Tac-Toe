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
        private Button _button;

        public Button button
        {
            get { return _button; }
            set 
            { 
                _button = value; 
                if((button.Content as SignEnum?) != null)
                {
                    Sign = button.Content as SignEnum?;
                }
            }
        }


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
