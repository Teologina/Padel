using System;
using Xunit;
using Padel;

namespace PadelTest
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            //Exempel på användning:
            Player player1 = new Player("Player 1");
            Player player2 = new Player("Player 2");

            var game = new Game(player1, player2);
            game.Point(player1); // 15 - 0
            game.Point(player1); // 30 - 0
            game.Point(player2); // 30 - 15
            game.Point(player1); // 40 - 15
            game.Point(player1); // Player 1 vinner Gamet

            var result = game.ScoreString(); // Ska vara Player 1 wins Game

        }
    }
}
