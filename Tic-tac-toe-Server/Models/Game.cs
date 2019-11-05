using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tic_tac_toe_Server.Models
{
    class Game
    {
        public int Size { get; set; }
        public List<UserModel> Players { get; set; }
        public List<List<int>> Map { get; set; }
    }
}
