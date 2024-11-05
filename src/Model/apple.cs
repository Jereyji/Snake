
namespace SnakeMVC.Models 
{
    public class AppleModel
    {
        private (int, int) coordinate;
        private readonly Random random = new();

        public (int, int) Coordinate
        {
            get 
            {
                return coordinate;
            }

            set
            {
                coordinate = value;
            }
        }

        public void PlaceRandomly(int width, int height, Queue<(int, int)> snakeCoordinates)
        {
            do
            {
                coordinate = (random.Next(1, height - 1), random.Next(1, width - 1));
            }
            while (snakeCoordinates.Contains(coordinate));
        }
    }
}