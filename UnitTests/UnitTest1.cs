using BowlingGameResultsReportingSystem;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

namespace UnitTests
{
    [TestFixture]
    public class UnitTest1
    {
        readonly string pathToTestFile = @"..\..\GameData.txt";
        GameSimulation gameSimulation;

        [Test]
        public void PlayerNames_LoadsCorrectly_FromFile()
        {
            // Arrange
            gameSimulation = new GameSimulation();
            List<string> expected = new List<string>() { "Paweł Kowalski", "Krzysztof Król", "Izabela Kania" };
            // Act
            var actual = gameSimulation.GetAllPlayersNames(pathToTestFile);
            // Assert
            Assert.IsTrue(expected.SequenceEqual(actual));
        }

        [Test]
        public void Scores_LoadsCorrectly_FromFile()
        {
            // Arrange
            gameSimulation = new GameSimulation();
            List<string> expected = new List<string>()
            {
                { "1, 2, 1, 2, 1, 2, 1, 2, 1, 2, 1, 2, 1, 2, 1, 2, 1, 2, 1, 2" },
                { "9, 1, 9, 1, 9, 1, 9, 1, 9, 1, 9, 1, 9, 1, 9, 1, 9, 1, 9, 1, 9" },
                { "4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4" }
            };
            // Act
            var actual = gameSimulation.GetAllScores(pathToTestFile);
            // Assert
            Assert.IsTrue(expected.SequenceEqual(actual));
        }

        [Theory]
        [TestCase(new int[] { 1, 2, 1, 2, 1, 2, 1, 2, 1, 2, 1, 2, 1, 2, 1, 2, 1, 2, 1, 2 }, ExpectedResult = 30)]
        public int PlayerFinalResult_AgreesWithTestCaseResults(int[] scores)
        {
            // Arrange
            gameSimulation = new GameSimulation();
            // Act
            var result = gameSimulation.CalculateResultFor(scores);
            // Assert
            return result;
        }
    }
}
