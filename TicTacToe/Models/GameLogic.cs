using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe.Models
{
    public static class GameLogic
    {
        public static bool CheckWin(GameMap map, SignEnum player)
        {
            if (CheckRows(map, player))
                return false;


            return false;
        }

        public static bool CheckRows(GameMap map, SignEnum player)
        {
            for(int i = 0; i < map.Size; i++)
            {
                int sum = 0;
                for(int x = 0; x < map.Size; x++)
                {
                    
                }
            }
            return false;
        }


    }
}
