using FluentAssertions;
using NUnit.Framework;

namespace BowlingTest
{
    public class Tests
    {
        private BowlingGame game;

        [SetUp]
        public void Setup()
        {
            game = new BowlingGame();
        }

        private void RollMany(int rolls, int pins)
        {
            for (int i = 0; i < rolls; i++)
            {
                game.Roll(pins);
            }
        }

        [Test]
        public void Roll_0_Pin_20_Times_Should_Return_0()
        {
            // Arrange
            RollMany(20, 0);

            // Act
            var score = game.Score();

            // Assert
            score.Should().Be(0);
        }

        [Test]
        public void Roll_1_Pin_20_Times_Should_Return_20()
        {
            // Arrange
            RollMany(20, 1);

            // Act
            var score = game.Score();

            // Assert
            score.Should().Be(20);
        }

        // first roll is 5 pins, second roll is 5 pins, third roll is 3 pins, 17 rolls are 0 pins
        [Test]
        public void Roll_Spare_Once_Should_Return_16()
        {
            // Arrange
            game.Roll(5);
            game.Roll(5);
            game.Roll(3);
            RollMany(17, 0);

            // Act
            var score = game.Score();

            // Assert
            score.Should().Be(16);
        }

        // first roll is 0 pin, second roll is 10 pins, third roll is 3 pins, fourth roll is 6 pins, fifth roll is 4 pins, sixth roll is 6 pins, seventh roll is 8 pins, the left rolls are 0 pins
        public void Roll_Spare_Twice_Should_Return_48()
        {
            // Arrange
            game.Roll(0);
            game.Roll(10);
            game.Roll(3);
            game.Roll(6);
            game.Roll(4);
            game.Roll(6);
            game.Roll(8);
            RollMany(13, 0);

            // Act
            var score = game.Score();

            // Assert
            score.Should().Be(48);
        }

        // when all the rolls get spares
        [Test]
        public void Roll_All_Spare_Should_Return_150()
        {
            // Arrange
            RollMany(21, 5);

            // Act
            var score = game.Score();

            // Assert
            score.Should().Be(150);
        }

        // when all the rolls get strikes
        [Test]
        public void Roll_All_Strike_Should_Return_300()
        {
            // Arrange
            RollMany(12, 10);

            // Act
            var score = game.Score();

            // Assert
            score.Should().Be(300);
        }
    }
}