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
                return true;

            if (CheckColumns(map, player))
                return true;

            if (CheckDiagonal(map, player))
                return true;

            if (CheckDiagonalReverse(map, player))
                return true;

            return false;
        }

        private static bool CheckRows(GameMap map, SignEnum player)
        {
            for(int i = 0; i < map.Size; i++)
            {
                int sum = 0;
                for(int x = 0; x < map.Size; x++)
                {
                    if (map.Tiles[i][x].Sign == player)
                        sum++;
                }
                if (CheckWin(sum, map))
                    return true;
            }
            return false;
        }

        private static bool CheckColumns(GameMap map, SignEnum player)
        {
            for (int i = 0; i < map.Size; i++)
            {
                int sum = 0;
                for (int x = 0; x < map.Size; x++)
                {
                    if (map.Tiles[x][i].Sign == player)
                        sum++;
                }
                if (CheckWin(sum, map))
                    return true;
            }
            return false;
        }

        private static bool CheckDiagonal(GameMap map, SignEnum player)
        {
            int sum = 0; 
            for(int i = 0; i < map.Size; i++)
            {
                if (map.Tiles[i][i].Sign == player)
                    sum++;
            }
            if (CheckWin(sum, map))
                return true;
            return false;
        }

        private static bool CheckDiagonalReverse(GameMap map, SignEnum player)
        {
            int sum = 0;
            int widthPos = map.Size - 1;
            for (int i = 0; i < map.Size; i++)
            {
                if (map.Tiles[i][widthPos].Sign == player)
                    sum++;
                widthPos--;
            }
            if (CheckWin(sum, map))
                return true;
            return false;
        }

        private static bool CheckWin(int sum, GameMap map)
        {
            return sum == map.Size;
        }
    }
}
