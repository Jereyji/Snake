
namespace SnakeMVC.Models
{
    public class FieldModel
    {
        public int Width { get; }
        public int Height { get; }
        public char[,] Grid { get; set; }

        public FieldModel(int width, int height)
        {
            Width = width;
            Height = height;
            Grid = new char[height, width];

        }

        public void InitializeGrid()
        {
            for (int y = 0; y < Height; y++)
            {
                for (int x = 0; x < Width; x++)
                {
                    Grid[y, x] = ' ';
                }
            }
        }
    }
}