using Game_of_Goose;

namespace GameOfGoose.Test
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [TestCase(2, 0, 2)]
        [TestCase(6, 0, 6)]
        [TestCase(7, 5, 12)]
        public void WhenPlayerMoveOnRegularLocation_ThenLogLocationNumber(int diceroll, int startPosition, int expectedLocation)
        {
            // Arrange
            var board = Gameboard.Instance();
            var player = new Player(1, "Player 1", startPosition);
            // Act
            player.MovePlayer(diceroll);
            // Assert
            Assert.That(player.Location.Id, Is.EqualTo(expectedLocation));
        }

        [TestCase(12, 2, 24)]
        public void WhenPlayerMoveOnGooseLocation_ThenLogLocationNumber(int diceroll, int startPosition, int expectedLocation)
        {
            // Arrange
            var player = new Player(1, "Player 1", startPosition);
            // Act
            player.MovePlayer(diceroll);
            // Assert
            Assert.That(player.Location.Id, Is.EqualTo(expectedLocation));
        }

        // wat als we op een goose komen,

        // wat als we na een goose weer op een goose komen

        // wat krijgen we als we terug aan het gaan zijn en op een goose komen.
    }
}