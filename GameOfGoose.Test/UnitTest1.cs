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
            var player = new Player(1, "Player 1", startPosition);
            // Act
            player.MovePlayer(diceroll);
            // Assert
            Assert.That(player.Location.Id, Is.EqualTo(expectedLocation));
        }

        [TestCase(5, 0, 10)]
        [TestCase(12, 2, 26)]
        public void WhenPlayerMoveOnGooseLocation_ThenLogLocationNumber(int diceroll, int startPosition, int expectedLocation)
        {
            // Arrange
            var player = new Player(1, "Player 1", startPosition);
            // Act
            player.MovePlayer(diceroll);
            // Assert
            Assert.That(player.Location.Id, Is.EqualTo(expectedLocation));
        }

        [TestCase(4, 10, 22)]
        [TestCase(5, 22, 32)]
        public void WhenPlayerMovesToGooseLocationComingFromGooseLocation_ThenLogLocationNumber(int diceroll, int startPosition, int expectedLocation)
        {
            // Arrange
            var player = new Player(1, "Player 1", startPosition);
            // Act
            player.MovePlayer(diceroll);
            // Assert
            Assert.That(player.Location.Id, Is.EqualTo(expectedLocation));
        }

        //moving Backward, Ik gebruik hier een negatieve diceroll voor, is dit correct?
        [TestCase(-4, 63, 55)]
        public void WhenPlayerMovingBackwardLandsOnGooseLocation_ThenLogLocationNumber(int diceroll, int startPosition, int expectedLocation)
        {
            // Arrange
            var player = new Player(1, "Player 1", startPosition);
            // Act
            player.MovePlayer(diceroll);
            // Assert
            Assert.That(player.Location.Id, Is.EqualTo(expectedLocation));
        }
        [TestCase(7, 12)]
        public void WhenPlayerMovesToInn_ThenPlayerSkipturnsChangesTo1(int diceroll, int startPosition)
        {
            //arrange
            var player = new Player(1, "Player 1", startPosition);
            //act
            player.MovePlayer(diceroll);
            //assert
            Assert.That(player.SkipTurns, Is.EqualTo(1));
        }
    }
}