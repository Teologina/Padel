using Xunit;
using Padel;

namespace PadelTest
{
    public class GameTest
    {
        [Fact]
        public void ScoreString_ShouldBeDeuceAlways()
        {
            Player p1 = new Player("teo");
            Player p2 = new Player("inteteo");
            Game game = new Game(p1, p2);

            p1.Score._Score = 4;
            p2.Score._Score = 5;

            for (int i = 0; i < 200; i++)
            {
                game.Point(p1);
                game.Point(p2);

            }


            var result = game.ScoreString();

            Assert.Equal("Match point", result);

        }

        [Theory]
        [InlineData(1, 5, "Player 1 wins")]
        [InlineData(2, 5, "Player 2 wins")]
        public void Game_test(int gameCase, int expectedScore, string expected)
        {
            Player player1 = new Player("Player 1");
            Player player2 = new Player("Player 2");

            var game = new Game(player1, player2);
            for (int i = 0; i < 5; i++)
            {
                if (gameCase == 1)
                {
                    game.Point(player1);
                }
                if (gameCase == 2)
                {
                    game.Point(player2);
                }
            }

            if (gameCase == 1) Assert.Equal(expectedScore, game.Score(player1)._Score);

            if (gameCase == 2) Assert.Equal(expectedScore, game.Score(player2)._Score);

            Assert.Equal(expected, game.ScoreString());
        }

        [Fact]
        public void Deuce_Test()
        {
            Player player1 = new Player("Player 1");
            Player player2 = new Player("Player 2");
            player1.Score._Score = 0;
            player2.Score._Score = 0;

            var game = new Game(player1, player2);
            game.Point(player1); //1
            game.Point(player2); //1
            game.Point(player1); //2
            game.Point(player2);//2
            game.Point(player1);//3
            game.Point(player2); //3
            game.Point(player1);//4
            game.Point(player2);//4


            var result = game.ScoreString();

            Assert.Equal("Deuce", result);

            //check when its 0-0
            //when someone wins after deuce
            //viktiga är många olika testfall inte att de behöver gå grönt, bra teckning på 1 klass än lite på alla. Gametest MKT!!!
            //båda 40 behöver då vinna 2 bollar för att vinna gem, vinner == 40 kallas deuce när båda har 40.
        }
        [Fact]
        public void WinnerAfterTwoGamesWonAfterDeuce_ShouldWork_Deuce()
        {
            Player player1 = new Player("Player 1");
            Player player2 = new Player("Player 2");
            Game game = new Game(player1, player2);

            player1.Score._Score = 5;
            player2.Score._Score = 7;

            var result = game.ScoreString();

            Assert.Equal("Player 2 wins", result);


        }
        [Fact]
        public void WinnerAfterOneGameWonAfterDeuce_ShouldNotWork_Deuce()
        {
            Player player1 = new Player("Player 1");
            Player player2 = new Player("Player 2");

            var game = new Game(player1, player2);
            for (int i = 0; i < 4; i++)
            {
                game.Point(player1);
                game.Point(player2);
                if (player1.Score._Score == 4)
                {
                    for (int j = 0; j < 1; j++)
                    {
                        game.Point(player1);
                    }
                }
            }
            var result = game.ScoreString();

            Assert.False("Player 1 wins" == result);
        }
    }
}
