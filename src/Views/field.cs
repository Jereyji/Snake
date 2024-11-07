
using SnakeMVC.Pkg;

namespace SnakeMVC.View
{
    public class Field
    {
        private readonly int width;
        private readonly int height;
        private char[,] grid;

        public Field(int width, int height)
        {
            this.width = width;
            this.height = height;
            grid = new char[height, width];
        }

        private void ClearGrid()
        {
            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    grid[y, x] = ' ';
                }
            }
        }

        public void FillGrid(Queue<(int, int)> snakeCoordinates, (int, int) appleCoordinate)
        {
            ClearGrid();

            foreach (var segment in snakeCoordinates)
            {
                grid[segment.Item1, segment.Item2] = Settings.SnakeSymbol;
            }

            grid[appleCoordinate.Item1, appleCoordinate.Item2] = Settings.AppleSymbol;
        }

        public void Draw(uint score)
        {
            Console.Clear();
            Console.WriteLine(new string(Settings.HorizontalBorder, width + 2));
            Console.WriteLine($"SCORE: {score}");
            Console.WriteLine(new string(Settings.HorizontalBorder, width + 2));

            for (int y = 0; y < height; y++)
            {
                Console.Write(Settings.VerticalBorder);
                
                for (int x = 0; x < width; x++)
                {
                    Console.Write(grid[y, x]);
                }

                Console.WriteLine(Settings.VerticalBorder);
            }

            Console.WriteLine(new string(Settings.HorizontalBorder, width + 2));
        }
    }
}