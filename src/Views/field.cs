
namespace SnakeMVC.View
{
    public class Field
    {
        const char horizontalBorder = '=';
        const char verticalBorder = '|';
        const char snakeSymbol = 'O';
        const char appleSymbol = '@';
        public int Width { get; }
        public int Height { get; }
        public char[,] Grid { get; set; }

        public Field(int width, int height)
        {
            Width = width;
            Height = height;
            Grid = new char[height, width];
        }

        private void ClearGrid()
        {
            for (int y = 0; y < Height; y++)
            {
                for (int x = 0; x < Width; x++)
                {
                    Grid[y, x] = ' ';
                }
            }
        }

        public void FillGrid(Queue<(int, int)> snakeCoordinates, (int, int) appleCoordinate)
        {
            ClearGrid();

            foreach (var segment in snakeCoordinates)
            {
                Grid[segment.Item1, segment.Item2] = snakeSymbol;
            }

            Grid[appleCoordinate.Item1, appleCoordinate.Item2] = appleSymbol;
        }

        public void Draw(uint score)
        {
            Console.Clear();
            Console.WriteLine(new string(horizontalBorder, Width + 2));
            Console.WriteLine($"SCORE: {score}");
            Console.WriteLine(new string(horizontalBorder, Width + 2));

            for (int y = 0; y < Height; y++)
            {
                Console.Write(verticalBorder);
                
                for (int x = 0; x < Width; x++)
                {
                    Console.Write(Grid[y, x]);
                }

                Console.WriteLine(verticalBorder);
            }

            Console.WriteLine(new string(horizontalBorder, Width + 2));
        }
    }
}