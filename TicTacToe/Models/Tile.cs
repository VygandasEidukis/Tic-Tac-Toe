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
            }
        }

        private SignEnum? _Sign;

        public SignEnum? Sign
        {
            get { return _Sign; }
            set { _Sign = value; }
        }
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

        public void Update(SignEnum? enu)
        {
            Sign = enu;
            button.Content = enu;
        }
    }
}
