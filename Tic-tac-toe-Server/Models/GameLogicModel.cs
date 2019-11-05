using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tic_tac_toe_Server.Models
{
    public class GameLogicModel
    {
        public int[] Place { get; set; } = new int[2] { 1, 1 };
        public int UserMark { get; set; } = 0;
    }
}
