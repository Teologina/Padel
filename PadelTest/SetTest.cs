using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using Padel;

namespace PadelTest
{
    public class SetTest
    {
        [Fact]
        public void Set_List_ShouldBeOneInstanceOfList()
        {
            var player1 = new Player("Alexandra");
            var player2 = new Player("Fredrik");
            var set = new Set(player1, player2);

            for (int i = 0; i < 5; i++)
            {
                set.Point(player1);
            }

            Assert.Single(set._games);
        }

        [Fact]
        public void Set_List_ShouldBeMoreThanOneInstanceOfList()
        {
            var player1 = new Player("Alexandra");
            var player2 = new Player("Fredrik");
            var set = new Set(player1, player2);

            //New list instance is created after 5th iteration of set.Point(player1);
            for (int i = 0; i < 6; i++)
            {
                set.Point(player1);
            }
            Assert.True(set._games.Count == 2);
        }

        [Fact]
        public void Set_List_AllInstanceShouldContainPlayer1Score()
        {
            var player1 = new Player("Alexandra");
            var player2 = new Player("Fredrik");
            var set = new Set(player1, player2);
            Game game = new Game(player1, player2);

            player1.Score._Score = 4;
            set.Point(player1); //Score gets added into set._games[0]
            set.Point(player1); // player score is above 4, so new list is created, indexed through set._games[1]


            Assert.Equal(set._games[0].Score(player1), player1.Score);
            Assert.Equal(set._games[1].Score(player1), player1.Score);
        }

        [Fact]
        public void Set_List_OnlyFirstInstanceShouldContainPlayer1Score()
        {
            var player1 = new Player("Alexandra");
            var player2 = new Player("Fredrik");
            var set = new Set(player1, player2);
            Game game = new Game(player1, player2);

            player1.Score._Score = 4;
            player2.Score._Score = 5;

            set.Point(player1);
            set.Point(player2);

            Assert.Equal(set._games[0].Score(player1), player1.Score);
            Assert.Equal(set._games[1].Score(player2), player2.Score);
        }
        [Fact]
        public void Set_List_SecondInstanceOfListShouldContainPlayer2Score()
        {
            var player1 = new Player("Alexandra");
            var player2 = new Player("Fredrik");
            Game game = new Game(player1, player2);
            var set = new Set(player1, player2);

            for (int i = 0; i < 5; i++)
            {
                game.Point(player2);
            }
            set.Point(player2);
            Assert.True(set._games[1].Score(player2) == player2.Score);
        }

        [Theory]
        [InlineData(3, 0, 3, 0)]
        [InlineData(0, 3, 0, 3)]
        [InlineData(1, 2, 1, 2)]
        public void Set_Point_Test(int player1score, int player2score, int expectedplayer1, int expectedplayer2)
        {
            int player1SetScore = 0;
            int player2SetScore = 0;

            var player1 = new Player("Alexandra");
            var player2 = new Player("Fredrik");
            var _set = new Set(player1, player2);



            for (int i = 0; i < player1score; i++)
            {
                _set.Point(player1);
                player1SetScore = _set._games[i].Score(player1)._Score;

            }


            for (int i = 0; i < player2score; i++)
            {
                _set.Point(player2);
                player2SetScore = _set._games[i].Score(player2)._Score;

            }

            Assert.Equal(expectedplayer1, player1SetScore);
            Assert.Equal(expectedplayer2, player2SetScore);
        }
    }
}