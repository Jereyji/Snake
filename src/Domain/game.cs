using SnakeMVC.Pkg;

namespace SnakeMVC.Domain
{
    public class Game
    {
        private readonly int width;
        private readonly int height;
        public Models.SnakeModel Snake;
        public Models.AppleModel Apple;
        public Models.ScoreModel InfoScore;

        public Game(int width, int height)
        {
            this.height = height;
            this.width = width;
            InfoScore = new();
            Snake = new();
            Apple = new();
            Apple.PlaceRandomly(width, height, Snake.Coordinates);
        }

        public bool Step((int, int) direction)
        {
            Snake.ChangeDirection(direction);

            if (Snake.CanMove(width, height))
            {
                Snake.Move();
            }
            else
            {
                return false;
            }

            if (Snake.HasEatenApple(Apple.Coordinate))
            {
                InfoScore.Score += Settings.AddingScore;
                Apple.PlaceRandomly(width, height, Snake.Coordinates);
            }
            else
            {
                Snake.Coordinates.Dequeue();
            }

            return true;
        }

        public bool HasPlayerWon()
        {
            return InfoScore.Score >= Settings.WinScore;
        }
    }
}