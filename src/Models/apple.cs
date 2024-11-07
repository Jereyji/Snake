
namespace SnakeMVC.Models
{
    public class AppleModel
    {
        public (int, int) Coordinate { get; private set; }
        private readonly Random _random = new();
        public void PlaceRandomly(int width, int height, Queue<(int, int)> snakeCoordinates)
        {
            do
            {
                Coordinate = (_random.Next(0, height - 1), _random.Next(0, width - 1));
            }
            while (snakeCoordinates.Contains(Coordinate));
        }
    }
}