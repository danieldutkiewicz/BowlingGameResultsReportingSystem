using BowlingGameResultsReportingSystem;
using NUnit.Framework;
using System.Linq;

namespace UnitTests
{
    [TestFixture]
    public class GameSimulatorTests
    {
        GameLoader gameSimulation;

        [Theory]
        [TestCase(@"..\..\..\TestFiles\UsualGame.txt", ExpectedResult = 112)]
        [TestCase(@"..\..\..\TestFiles\LastIsStrike.txt", ExpectedResult = 88)]
        [TestCase(@"..\..\..\TestFiles\LastIsSpare.txt", ExpectedResult = 125)]
        [TestCase(@"..\..\..\TestFiles\PerfectGame.txt", ExpectedResult = 300)]
        public int PlayerFinalResult_AgreesWithTestCaseResults(string pathToTestFile)
        {
            // Arrange
            gameSimulation = new GameLoader();
            // Act
            var games = gameSimulation.LoadAllGamesFromFile(pathToTestFile);
            var rollingResults = games.Select(g => g.RollingResult.Last());          
            // Assert
            return rollingResults.First();
        }
    }
}
