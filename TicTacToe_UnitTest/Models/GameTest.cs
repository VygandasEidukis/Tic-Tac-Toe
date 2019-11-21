using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TicTacToe.Models;
using Xunit;
using Assert = Xunit.Assert;

namespace TicTacToe_UnitTest.Models
{
    public class GameTest
    {
        [Fact]
        public void TileClicked_ShouldFail_WithIncorrectObject()
        {
            var game = new Game();

            Assert.Throws<Exception>(() => { game.TileClicked(new Game(), null); });
        }

        [Fact]
        public void Constructor_ShouldCreateMap_WhenCreated()
        {
            var actual = new Game().Map != null;
            var expected = true;

            Assert.Equal(expected,actual);
        }

        [Fact]
        public void CurrentPlayerTurn_ShouldSwitchTurns_WhenSettingValue()
        {
            var game = new Game();

            game.CurrentPlayerTurn = new Player();
            var actual = game.CurrentPlayerTurn.Id;
            var expected = game.Players.Find(player => player.Sign == SignEnum.X).Id;

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Players_ShouldContainTwo_WhenGameIsCreated()
        {
            var game = new Game();

            var expected = 2;
            var actual = game.Players.Count();

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Players_ShouldGet_FirstPlayer()
        {
            var game = new Game();

            Player actual = game.Players.Find(f => f.Id == 0);
            Player expected = game.Players[0];

            Assert.Equal(expected, actual);
        }
    }
}
