using NUnit.Framework;

namespace Tennis
{
  [TestFixture]
  public class Describe_game
  {
    [Test]
    public void GameStartsWithZeroPoints()
    {
      var game = new Game();

      Assert.AreEqual("0:0", game.GetAnnouncement());
    }

    [Test]
    public void Player1FirstScoreIs15()
    {
      var game = new Game().PlayerOneScores();

      Assert.AreEqual("15:0", game.GetAnnouncement());
    }

    [Test]
    public void Player2FirstScoreIs15()
    {
      var game = new Game().PlayerTwoScores();

      Assert.AreEqual("0:15", game.GetAnnouncement());
    }

    [Test]
    public void Player1SecondScoreIs30()
    {
      var game = new Game()
        .PlayerOneScores()
        .PlayerOneScores();

      Assert.AreEqual("30:0", game.GetAnnouncement());
    }

    [Test]
    public void Player2SecondScoreIs30()
    {
      var game = new Game()
        .PlayerTwoScores()
        .PlayerTwoScores();

      Assert.AreEqual("0:30", game.GetAnnouncement());
    }

    [Test]
    public void Player1ThirdScoreIs40()
    {
      var game = new Game()
        .PlayerOneScores()
        .PlayerOneScores()
        .PlayerOneScores();

      Assert.AreEqual("40:0", game.GetAnnouncement());
    }

    [Test]
    public void Player2ThirdScoreIs40()
    {
      var game = new Game()
        .PlayerTwoScores()
        .PlayerTwoScores()
        .PlayerTwoScores();

      Assert.AreEqual("0:40", game.GetAnnouncement());
    }

    [Test]
    public void Player1WinsStraight()
    {
      var game = new Game()
        .PlayerOneScores()
        .PlayerOneScores()
        .PlayerOneScores()
        .PlayerOneScores();

      Assert.AreEqual("player 1 wins", game.GetAnnouncement());
    }

    [Test]
    public void Player2WinsStraight()
    {
      var game = new Game()
        .PlayerTwoScores()
        .PlayerTwoScores()
        .PlayerTwoScores()
        .PlayerTwoScores();

      Assert.AreEqual("player 2 wins", game.GetAnnouncement());
    }

    [Test]
    public void Player1ScoreIsKeptWhenPlayer2Scores()
    {
      var game = new Game()
        .PlayerOneScores()
        .PlayerTwoScores();

      Assert.AreEqual("15:15", game.GetAnnouncement());
    }

    [Test]
    public void Deuce()
    {
      var game = new Game()
        .PlayerOneScores()
        .PlayerOneScores()
        .PlayerOneScores()
        .PlayerTwoScores()
        .PlayerTwoScores()
        .PlayerTwoScores();

      Assert.AreEqual("deuce", game.GetAnnouncement());
    }

    [Test]
    public void AdvantagePlayer1()
    {
      var game = new Game()
        .PlayerOneScores()
        .PlayerOneScores()
        .PlayerOneScores()
        .PlayerTwoScores()
        .PlayerTwoScores()
        .PlayerTwoScores()
        .PlayerOneScores();

      Assert.AreEqual("advantage player 1", game.GetAnnouncement());
    }

    [Test]
    public void AdvantagePlayer2()
    {
      var game = new Game()
        .PlayerOneScores()
        .PlayerOneScores()
        .PlayerOneScores()
        .PlayerTwoScores()
        .PlayerTwoScores()
        .PlayerTwoScores()
        .PlayerTwoScores();

      Assert.AreEqual("advantage player 2", game.GetAnnouncement());
    }

    [Test]
    public void BackToDeuceAfterPlayer1Advantage()
    {
      var game = new Game()
        .PlayerOneScores()
        .PlayerOneScores()
        .PlayerOneScores()
        .PlayerTwoScores()
        .PlayerTwoScores()
        .PlayerTwoScores()
        .PlayerOneScores()
        .PlayerTwoScores();

      Assert.AreEqual("deuce", game.GetAnnouncement());
    }

    [Test]
    public void BackToDeuceAfterPlayer2Advantage()
    {
      var game = new Game()
        .PlayerOneScores()
        .PlayerOneScores()
        .PlayerOneScores()
        .PlayerTwoScores()
        .PlayerTwoScores()
        .PlayerTwoScores()
        .PlayerTwoScores()
        .PlayerOneScores();

      Assert.AreEqual("deuce", game.GetAnnouncement());
    }

    [Test]
    public void Player1WinsAfterAdvantage()
    {
      var game = new Game()
        .PlayerOneScores()
        .PlayerOneScores()
        .PlayerOneScores()
        .PlayerTwoScores()
        .PlayerTwoScores()
        .PlayerTwoScores()
        .PlayerOneScores()
        .PlayerOneScores();

      Assert.AreEqual("player 1 wins", game.GetAnnouncement());
    }

    [Test]
    public void Player2WinsAfterAdvantage()
    {
      var game = new Game()
        .PlayerOneScores()
        .PlayerOneScores()
        .PlayerOneScores()
        .PlayerTwoScores()
        .PlayerTwoScores()
        .PlayerTwoScores()
        .PlayerTwoScores()
        .PlayerTwoScores();

      Assert.AreEqual("player 2 wins", game.GetAnnouncement());
    }
  }
}
