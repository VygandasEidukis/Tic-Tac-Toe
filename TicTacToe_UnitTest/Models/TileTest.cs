using TicTacToe.Models;
using Xunit;

namespace TicTacToe_UnitTest.Models
{
    public class TileTest
    {
        public Tile Tile { get; set; }

        public TileTest()
        {
            Tile = new Tile();
        }

        [Theory]
        [InlineData(SignEnum.X, SignEnum.X)]
        [InlineData(SignEnum.O, SignEnum.O)]
        [InlineData(null, null)]
        public void Update_ShouldChangeSigns_WithAnySign(SignEnum? sign, SignEnum? expected)
        {
            Tile.Update(sign);

            Assert.Equal(expected, Tile.Sign);
        }
    }
}
