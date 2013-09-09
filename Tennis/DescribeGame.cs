using System;

using NUnit.Framework;

namespace Tennis
{
  [TestFixture]
  public class Describe_game
  {
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

      Assert.IsAssignableFrom<AdvantagePoint>(game.PlayerOnePoints);
      Assert.IsAssignableFrom<_40Points>(game.PlayerTwoPoints);
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

      Assert.IsAssignableFrom<_40Points>(game.PlayerOnePoints);
      Assert.IsAssignableFrom<AdvantagePoint>(game.PlayerTwoPoints);
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

      Assert.IsAssignableFrom<_40Points>(game.PlayerOnePoints);
      Assert.IsAssignableFrom<_40Points>(game.PlayerTwoPoints);
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

      Assert.IsAssignableFrom<_40Points>(game.PlayerOnePoints);
      Assert.IsAssignableFrom<_40Points>(game.PlayerTwoPoints);
      Assert.AreEqual("deuce", game.GetAnnouncement());
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

      Assert.IsAssignableFrom<_40Points>(game.PlayerOnePoints);
      Assert.IsAssignableFrom<_40Points>(game.PlayerTwoPoints);
      Assert.AreEqual("deuce", game.GetAnnouncement());
    }

    [Test]
    public void GameStartsWithZeroPoints()
    {
      var game = new Game();

      Assert.IsAssignableFrom<ZeroPoints>(game.PlayerOnePoints);
      Assert.IsAssignableFrom<ZeroPoints>(game.PlayerTwoPoints);
      Assert.AreEqual("0:0", game.GetAnnouncement());
    }

    [Test]
    public void Player1FirstScoreIs15()
    {
      var game = new Game().PlayerOneScores();

      Assert.IsAssignableFrom<_15Points>(game.PlayerOnePoints);
      Assert.AreEqual("15:0", game.GetAnnouncement());
    }

    [Test]
    public void Player1ScoreIsKeptWhenPlayer2Scores()
    {
      var game = new Game()
        .PlayerOneScores()
        .PlayerTwoScores();

      Assert.IsAssignableFrom<_15Points>(game.PlayerOnePoints);
      Assert.IsAssignableFrom<_15Points>(game.PlayerTwoPoints);
      Assert.AreEqual("15:15", game.GetAnnouncement());
    }

    [Test]
    public void Player1SecondScoreIs30()
    {
      var game = new Game()
        .PlayerOneScores()
        .PlayerOneScores();

      Assert.IsAssignableFrom<_30Points>(game.PlayerOnePoints);
      Assert.AreEqual("30:0", game.GetAnnouncement());
    }

    [Test]
    public void Player1ThirdScoreIs40()
    {
      var game = new Game()
        .PlayerOneScores()
        .PlayerOneScores()
        .PlayerOneScores();

      Assert.IsAssignableFrom<_40Points>(game.PlayerOnePoints);
      Assert.AreEqual("40:0", game.GetAnnouncement());
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

      Assert.IsAssignableFrom<GamePoint>(game.PlayerOnePoints);
      Assert.IsAssignableFrom<_40Points>(game.PlayerTwoPoints);
      Assert.AreEqual("player 1 wins", game.GetAnnouncement());
    }

    [Test]
    public void Player1WinsStraight()
    {
      var game = new Game()
        .PlayerOneScores()
        .PlayerOneScores()
        .PlayerOneScores()
        .PlayerOneScores();

      Assert.IsAssignableFrom<GamePoint>(game.PlayerOnePoints);
      Assert.AreEqual("player 1 wins", game.GetAnnouncement());
    }

    [Test]
    public void Player2FirstScoreIs15()
    {
      var game = new Game().PlayerTwoScores();

      Assert.IsAssignableFrom<_15Points>(game.PlayerTwoPoints);
      Assert.AreEqual("0:15", game.GetAnnouncement());
    }

    [Test]
    public void Player2SecondScoreIs30()
    {
      var game = new Game()
        .PlayerTwoScores()
        .PlayerTwoScores();

      Assert.IsAssignableFrom<_30Points>(game.PlayerTwoPoints);
      Assert.AreEqual("0:30", game.GetAnnouncement());
    }

    [Test]
    public void Player2ThirdScoreIs40()
    {
      var game = new Game()
        .PlayerTwoScores()
        .PlayerTwoScores()
        .PlayerTwoScores();

      Assert.IsAssignableFrom<_40Points>(game.PlayerTwoPoints);
      Assert.AreEqual("0:40", game.GetAnnouncement());
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

      Assert.IsAssignableFrom<_40Points>(game.PlayerOnePoints);
      Assert.IsAssignableFrom<GamePoint>(game.PlayerTwoPoints);
      Assert.AreEqual("player 2 wins", game.GetAnnouncement());
    }

    [Test]
    public void Player2WinsStraight()
    {
      var game = new Game()
        .PlayerTwoScores()
        .PlayerTwoScores()
        .PlayerTwoScores()
        .PlayerTwoScores();

      Assert.IsAssignableFrom<GamePoint>(game.PlayerTwoPoints);
      Assert.AreEqual("player 2 wins", game.GetAnnouncement());
    }
  }

  public class Game
  {
    public Game()
    {
      PlayerOnePoints = new ZeroPoints();
      PlayerTwoPoints = new ZeroPoints();
    }

    public IPoints PlayerOnePoints { get; private set; }
    public IPoints PlayerTwoPoints { get; private set; }

    public Game PlayerOneScores()
    {
      return new Game
      {
        PlayerOnePoints = PlayerOnePoints.Win(PlayerTwoPoints),
        PlayerTwoPoints = PlayerTwoPoints.Lose()
      };
    }

    public Game PlayerTwoScores()
    {
      return new Game
      {
        PlayerOnePoints = PlayerOnePoints.Lose(),
        PlayerTwoPoints = PlayerTwoPoints.Win(PlayerOnePoints)
      };
    }

    public string GetAnnouncement()
    {
      if (PlayerOnePoints is _40Points && PlayerTwoPoints is _40Points)
      {
        return "deuce";
      }

      if (PlayerOnePoints is AdvantagePoint)
      {
        return "advantage player 1";
      }

      if (PlayerTwoPoints is AdvantagePoint)
      {
        return "advantage player 2";
      }

      if (PlayerOnePoints is GamePoint)
      {
        return "player 1 wins";
      }

      if (PlayerTwoPoints is GamePoint)
      {
        return "player 2 wins";
      }

      return String.Format("{0}:{1}", PlayerOnePoints.Announce(), PlayerTwoPoints.Announce());
    }
  }

  public interface IPoints
  {
    IPoints Win(IPoints otherPlayerPoints);
    IPoints Lose();
    string Announce();
  }

  class ZeroPoints : IPoints
  {
    public IPoints Win(IPoints otherPlayerPoints)
    {
      return new _15Points();
    }

    public IPoints Lose()
    {
      return this;
    }

    public string Announce()
    {
      return "0";
    }
  }

  class _15Points : IPoints
  {
    public IPoints Win(IPoints otherPlayerPoints)
    {
      return new _30Points();
    }

    public IPoints Lose()
    {
      return this;
    }

    public string Announce()
    {
      return "15";
    }
  }

  class _30Points : IPoints
  {
    public IPoints Win(IPoints otherPlayerPoints)
    {
      return new _40Points();
    }

    public IPoints Lose()
    {
      return this;
    }

    public string Announce()
    {
      return "30";
    }
  }

  class _40Points : IPoints
  {
    public IPoints Win(IPoints otherPlayerPoints)
    {
      if (otherPlayerPoints is _40Points)
      {
        return new AdvantagePoint();
      }

      if (otherPlayerPoints is AdvantagePoint)
      {
        return new _40Points();
      }

      return new GamePoint();
    }

    public IPoints Lose()
    {
      return this;
    }

    public string Announce()
    {
      return "40";
    }
  }

  public class AdvantagePoint : IPoints
  {
    public IPoints Win(IPoints otherPlayerPoints)
    {
      return new GamePoint();
    }

    public IPoints Lose()
    {
      return new _40Points();
    }

    public string Announce()
    {
      return "ignored";
    }
  }

  public class GamePoint : IPoints
  {
    public IPoints Win(IPoints otherPlayerPoints)
    {
      throw new InvalidOperationException("Game is over");
    }

    public IPoints Lose()
    {
      throw new InvalidOperationException("Game is over");
    }

    public string Announce()
    {
      return "ignored";
    }
  }
}
