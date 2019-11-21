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

        public void Update(SignEnum? enu)
        {
            Sign = enu;
            if (Button != null)
            {
                Button.Content = enu;
            }
        }
    }
}
