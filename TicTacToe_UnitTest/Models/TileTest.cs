using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Documents;
using TicTacToe.Models;
using Xunit;

namespace TicTacToe_UnitTest.Models
{
    public class TileTest
    {
        public Tile tile { get; set; }

        public TileTest()
        {
            tile = new Tile();
        }

        [Theory]
        [InlineData(SignEnum.X, SignEnum.X)]
        [InlineData(SignEnum.O, SignEnum.O)]
        [InlineData(null, null)]
        public void Update_ShouldChangeSigns_WithAnySign(SignEnum? sign, SignEnum? expected)
        {
            tile.Update(sign);

            Assert.Equal(expected, tile.Sign);
        }
    }
}
