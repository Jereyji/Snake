
namespace SnakeMVC.View
{
    public class DrawView
    {
        const char horizontalBorder = '_';
        const char verticalBorder = '|';

        public void Draw(Models.FieldModel field)
        {
            Console.Clear();
            Console.WriteLine(new string(horizontalBorder, field.Width));

            for (int y = 0; y < field.Height; y++)
            {
                Console.Write(verticalBorder);
                for (int x = 0; x < field.Width; x++)
                {
                    Console.Write(field.Grid[y, x]);
                }
                Console.WriteLine(verticalBorder);
            }

            Console.WriteLine(new string(horizontalBorder, field.Width));
        }
    }
}