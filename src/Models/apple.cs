
namespace SnakeMVC.Models
{
    public class AppleModel
    {
        public (int, int) Coordinate { get; set; }
        private readonly Random random = new();
        public void PlaceRandomly(int width, int height, Queue<(int, int)> snakeCoordinates)
        {
            do
            {
                Coordinate = (random.Next(0, height - 1), random.Next(0, width - 1));
            }
            while (snakeCoordinates.Contains(Coordinate));
        }
    }
}