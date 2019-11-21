using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicTacToe.Models;
using Xunit;
using System.Reflection;

namespace TicTacToe_UnitTest.Models
{
    public class GameLogicTest
    {
        
        public GameMap Map { get; set; }

        public GameLogicTest()
        {
            Map = new GameMap {Size = 3};
            for (var i = 0; i < Map.Size; i++)
            {
                for (var x = 0; x < Map.Size; x++)
                {
                    Map.Tiles[i][x].Sign = SignEnum.O;
                }
            }
        }

        [Theory]
        [InlineData(SignEnum.O, true)]
        [InlineData(SignEnum.X, false)]
        public void CheckRows_ShouldReturnTrue_WhenRowIsSameSign(SignEnum sign, bool expected)
        {
            var actual = GameLogic.CheckRows(Map, sign);
            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData(SignEnum.O, true)]
        [InlineData(SignEnum.X, false)]
        public void CheckDiagonal_ShouldReturnTrue_WhenDiagonalIsSameSign(SignEnum sign, bool expected)
        {
            var actual = GameLogic.CheckDiagonal(Map, sign);
            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData(SignEnum.O, true)]
        [InlineData(SignEnum.X, false)]
        public void CheckrDiagonal_ShouldReturnTrue_WhenrDiagonalIsSameSign(SignEnum sign, bool expected)
        {
            var actual = GameLogic.CheckDiagonalReverse(Map, sign);
            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData(SignEnum.O, true)]
        [InlineData(SignEnum.X, false)]
        public void CheckColumn_ShouldReturnTrue_WhenColumnIsSameSign(SignEnum sign, bool expected)
        {
            var actual = GameLogic.CheckDiagonalReverse(Map, sign);
            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData(SignEnum.O, true)]
        [InlineData(SignEnum.X, false)]
        public void CheckWin_ShouldReturnTrue_WhenSignsAreEqualToMapSize(SignEnum sign, bool expected)
        {
            var actual = GameLogic.CheckWin(Map, sign);
            Assert.Equal(expected, actual);
        }
    }
}
