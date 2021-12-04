using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using Padel;

namespace PadelTest
{
    public class ScoreTest
    {
        [Theory]
        [InlineData(1, 1)]
        [InlineData(2, 2)]
        [InlineData(3, 3)]
        public void Score_Test(int nrOfTimes, int expected)
        {
            var score = new Score();

            for (int i = 0; i < nrOfTimes; i++)
            {
                score.Increase();
            }

            Assert.Equal(expected, score._Score);

        }


        [Fact]
        public void Increase_ShouldNotAllowDecreaseInScore()
        {
            Player p1 = new Player("teo");
            Player p2 = new Player("inteteo");
            Game game = new Game(p1, p2);

            game.Point(p1);
            int minus = 1;
            p1.Score._Score = p1.Score._Score - minus; //Deduction should not be allowed.

            Assert.Equal(1, p1.Score._Score);
            //Bug. Should not be able to reduce score.

        }

        [Fact]
        public void Score_Shold_Not_Allow_Negativ_Value() //this is a bugg, should not be able to reduce score.
        {
            var player1 = new Player("Alexandra");
            var player2 = new Player("Fredrik");
            var game = new Game(player1, player2);

            game.Point(player1);

            int negativValue = 1;
            player1.Score._Score = player1.Score._Score - negativValue;
            Assert.Equal(0, player1.Score._Score);
        }
    }
}
