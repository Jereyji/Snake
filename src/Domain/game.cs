namespace SnakeMVC.Domain
{
    public class Game
    {
        const uint addingScore = 500;
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
            if (Snake.CheckNextMove(direction, width, height))
            {
                Snake.Move();
            }
            else
            {
                return false;
            }

            if (Snake.CheckApple(Apple.Coordinate))
            {
                InfoScore.Score += addingScore;
                Apple.PlaceRandomly(width, height, Snake.Coordinates);
            }

            return true;
        }
    }
}