using Game_of_Goose;
using Game_of_Goose.Location;
using System.Numerics;

namespace GameOfGoose.Test
{
    public class Tests
    {
 

        [TestCase(2, 0, 2)]
        [TestCase(4, 0, 4)]
        [TestCase(7, 5, 12)]
        public void WhenPlayerMoveOnRegularLocation_ThenLogLocationNumber(int diceroll, int startPosition, int expectedLocation)
        {
            // Arrange
            var player = new Player(1, "Player 1", startPosition);
            Dice dice = new Dice();
            dice.DiceTotal = diceroll;
            // Act
            player.MovePlayer(dice);
            // Assert
            Assert.That(player.Location.Id, Is.EqualTo(expectedLocation));
        }

        [TestCase(5, 0, 10)]
        [TestCase(12, 2, 26)]
        public void WhenPlayerMoveOnGooseLocation_ThenLogLocationNumber(int diceroll, int startPosition, int expectedLocation)
        {
            // Arrange
            var player = new Player(1, "Player 1", startPosition);
            Dice dice = new Dice();
            dice.DiceTotal = diceroll;
            // Act
            player.MovePlayer(dice);
            // Assert
            Assert.That(player.Location.Id, Is.EqualTo(expectedLocation));
        }

        [TestCase(4, 10, 22)]
        [TestCase(5, 22, 32)]
        public void WhenPlayerMovesToGooseLocationComingFromGooseLocation_ThenLogLocationNumber(int diceroll, int startPosition, int expectedLocation)
        {
            // Arrange
            var player = new Player(1, "Player 1", startPosition);
            Dice dice = new Dice();
            dice.DiceTotal = diceroll;
            // Act
            player.MovePlayer(dice);
            // Assert
            Assert.That(player.Location.Id, Is.EqualTo(expectedLocation));
        }

        [TestCase(4, 63, 55)]
        public void WhenPlayerMovingBackwardLandsOnGooseLocation_ThenLogLocationNumber(int diceroll, int startPosition, int expectedLocation)
        {
            // Arrange
            var player = new Player(1, "Player 1", startPosition);
            Dice dice = new Dice();
            dice.DiceTotal = diceroll;
            // Act
            player.MovePlayer(dice);
            // Assert
            Assert.That(player.Location.Id, Is.EqualTo(expectedLocation));
        }

        [TestCase(7, 12)]
        public void WhenPlayerMovesToInn_ThenPlayerSkipturnsChangesTo1(int diceroll, int startPosition)
        {
            //arrange
            var player = new Player(1, "Player 1", startPosition);
            Dice dice = new Dice();
            dice.DiceTotal = diceroll;
            //act
            player.MovePlayer(dice);
            //assert
            Assert.That(player.SkipTurns, Is.EqualTo(1));
        }
        [TestCase(8, 44)]
        [TestCase(5, 47)]

        public void WhenPlayerMovesToPrison_ThenPlayerSkipturnsChangesTo3(int diceroll, int startPosition)
        {
            //arrange
            var player = new Player(1, "Player 1", startPosition);
            Dice dice = new Dice();
            dice.DiceTotal = diceroll;
            //act
            player.MovePlayer(dice);
            //assert
            Assert.That(player.SkipTurns, Is.EqualTo(3));
        }

        [TestCase(3, 61, 62)]
        [TestCase(6, 60, 60)]
        public void WhenPlayerMovesPast63_ThenPlayerMovesBackRestOfDiceroll(int diceroll, int startPosition, int expectedlocation)
        {
            //arrange
            var player = new Player(1, "Player 1", startPosition);
            Dice dice = new Dice();
            dice.DiceTotal = diceroll;
            //act
            player.MovePlayer(dice);
            //assert
            Assert.That(player.Location.Id, Is.EqualTo(expectedlocation));
        }

        [TestCase(8, 59, 51)]
        public void WhenPlayerMovesPast63TurnsBackAndLandsOnAGoose_ThenLogLocationNumber(int diceroll, int startPosition, int expectedlocation)
        {
            //arrange
            var player = new Player(1, "Player 1", startPosition);
            Dice dice = new Dice();
            dice.DiceTotal = diceroll;
            //act
            player.MovePlayer(dice);
            //assert
            Assert.That(player.Location.Id, Is.EqualTo(expectedlocation));
        }

        [TestCase(6, 0, 12)]
        [TestCase(3, 3, 12)]
        public void WhenPlayerLandsOnBridge_ThenLocationIdIs12(int diceroll, int startPosition, int expectedlocation)
        {
            //arrange
            var player = new Player(1, "Player 1", startPosition);
            Dice dice = new Dice();
            dice.DiceTotal = diceroll;
            //act
            player.MovePlayer(dice);
            //assert
            Assert.That(player.Location.Id, Is.EqualTo(expectedlocation));
        }

        [TestCase(7, 35)]
        [TestCase(3, 39)]
        public void WhenPlayerLandsOnMaze_ThenLocationIdIs39(int diceroll, int startPosition)
        {
            //arrange
            var player = new Player(1, "Player 1", startPosition);
            Dice dice = new Dice();
            dice.DiceTotal = diceroll;
            //act
            player.MovePlayer(dice);
            //assert
            Assert.That(player.Location.Id, Is.EqualTo(39));
        }
        [TestCase(8, 50)]
        [TestCase(12, 46)]
        public void WhenPlayerLandsOnDeath_ThenLocationIdIs0(int diceroll, int startPosition)
        {
            //arrange
            var player = new Player(1, "Player 1", startPosition);
            Dice dice = new Dice();
            dice.DiceTotal = diceroll;
            //act
            player.MovePlayer(dice);
            //assert
            Assert.That(player.Location.Id, Is.EqualTo(0));
        }
        [TestCase(5, 31)]
        [TestCase(12, 31)]
        public void WhenPlayerIsInWell_ThenPlayerCantMove(int diceroll, int startPosition)
        {
            //arrange
            var player = new Player(1, "Player 1", startPosition);
            player.InWell = true;
            Dice dice = new Dice();
            dice.DiceTotal = diceroll;
            //act
            player.MovePlayer(dice);
            //assert
            Assert.That(player.Location.Id, Is.EqualTo(startPosition));
        }
        [TestCase(5, 26)]
        [TestCase(12, 19)]
        public void WhenPlayerOneArrivesInWell_ThenOtherPlayerInWellIsNotInWellAnymore(int dicerollPlayerOne, int startPositionPlayerOne)
        {
            int locationIdWell = 31;
            //arrange
            var playerOne = new Player(1, "player 1", startPositionPlayerOne);
            var playerTwo = new Player(2, "player 2 ", locationIdWell);
            playerTwo.InWell = true;
           var well = (Well)Gameboard.Instance().GetLocation(31);
            well.PlayerInWell = playerTwo;
            Dice dice = new Dice();
            dice.DiceTotal = dicerollPlayerOne;
            //act
            playerOne.MovePlayer(dice);
            //assert
            Assert.That(playerTwo.InWell, Is.False);
           
        }
        [TestCase(5, 26)]
        [TestCase(12, 19)]
        public void WhenPlayerOneArrivesInWell_ThenPlayerOneBecomesPlayerInWell(int dicerollPlayerOne, int startPositionPlayerOne)
        {
            int locationIdWell = 31;
            //arrange
            var playerOne = new Player(1, "player 1", startPositionPlayerOne);
            var playerTwo = new Player(2, "player 2 ", locationIdWell);
            playerTwo.InWell = true;
            var well = (Well)Gameboard.Instance().GetLocation(31);
            well.PlayerInWell = playerTwo;
            Dice dice = new Dice();
            dice.DiceTotal = dicerollPlayerOne;
            //act
            playerOne.MovePlayer(dice);
            //assert
            Assert.That(playerOne.InWell, Is.True);
            Assert.That(well.PlayerInWell, Is.EqualTo(playerOne));
        }
        [TestCase(4, 59)]
        [TestCase(12, 51)]
        public void WhenPlayerMovesToEndLocation_ThenPlayerIsWinner(int diceroll, int startPosition)
        {
            // Arrange
            var player = new Player(1, "Player 1", startPosition);
            Dice dice = new Dice();
            dice.DiceTotal = diceroll;
            //act
            player.MovePlayer(dice);
            // Assert
            Assert.That(player.IsWinner, Is.True);
        }

    }
}