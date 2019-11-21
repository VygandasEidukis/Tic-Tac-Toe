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

        public static bool CheckRows(GameMap map, SignEnum player)
        {
            for(var i = 0; i < map.Size; i++)
            {
                var sum = 0;
                for(var x = 0; x < map.Size; x++)
                {
                    if (map.Tiles[i][x].Sign == player)
                        sum++;
                }
                if (CheckWin(sum, map))
                    return true;
            }
            return false;
        }

        public static bool CheckColumns(GameMap map, SignEnum player)
        {
            for (var i = 0; i < map.Size; i++)
            {
                var sum = 0;
                for (var x = 0; x < map.Size; x++)
                {
                    if (map.Tiles[x][i].Sign == player)
                        sum++;
                }
                if (CheckWin(sum, map))
                    return true;
            }
            return false;
        }

        public static bool CheckDiagonal(GameMap map, SignEnum player)
        {
            var sum = 0; 
            for(var i = 0; i < map.Size; i++)
            {
                if (map.Tiles[i][i].Sign == player)
                    sum++;
            }
            return CheckWin(sum, map);
        }

        public static bool CheckDiagonalReverse(GameMap map, SignEnum player)
        {
            var sum = 0;
            var widthPos = map.Size - 1;
            for (var i = 0; i < map.Size; i++)
            {
                if (map.Tiles[i][widthPos].Sign == player)
                    sum++;
                widthPos--;
            }
            return CheckWin(sum, map);
        }
        public static bool CheckWin(int sum, GameMap map)
        {
            return sum == map.Size;
        }
    }
}
