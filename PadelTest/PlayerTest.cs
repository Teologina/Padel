using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using Padel;

namespace PadelTest
{
    public class PlayerTest
    {
        [Fact]
        public void PlayerTest_Check_Name_NotNull()
        {
            var player1 = new Player("Alexandra");
            var player2 = new Player("Fredrik");

            Assert.NotNull(player1.Name);
            Assert.NotNull(player2.Name); //check if null


        }
        [Fact]
        public void PlayerTest_Check_Name_Empty()
        {
            var player1 = new Player("Alexandra");
            var player2 = new Player("Fredrik");

            Assert.NotEmpty(player1.Name); //check if not empty
            Assert.NotEmpty(player2.Name); //check if not empty

        }

        [Theory]
        [InlineData(1, 1)]
        [InlineData(2, 2)]
        [InlineData(3, 3)]
        public void Player_Point_Score(int nrOfTimes, int expected)
        {
            var player1 = new Player("Alexandra");

            for (int i = 0; i < nrOfTimes; i++)
            {
                player1.Point();
            }

            Assert.Equal(expected, player1.Score._Score);

        }
    }
}
