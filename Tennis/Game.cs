using System;

namespace Tennis
{
  public class Game
  {
    interface IPoints
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

    class AdvantagePoint : IPoints
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

    class GamePoint : IPoints
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

    public Game()
    {
      PlayerOnePoints = new ZeroPoints();
      PlayerTwoPoints = new ZeroPoints();
    }

    IPoints PlayerOnePoints { get; set; }
    IPoints PlayerTwoPoints { get; set; }

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
}