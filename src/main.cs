using System;
using System.Threading;

// NEED: realize MVC, visitor
// TODO: отрисовка поля
// TODO: считывание команд (w,a,s,d,q)
// TODO: рандомизация появления бонуса, если отсутствует на поле
// TODO: поедание бонуса -> увеличение змеи
// TODO: счетчик
// TODO: 

class Program
{
    const int width = 30;
    const int height = 10;

    const char snakeSymbol = 'O';
    const char appleSymbol = 'O';

    static void Main()
    {
        SnakeMVC.Models.FieldModel field = new(width, height);
        SnakeMVC.Models.SnakeModel snake = new();
        SnakeMVC.Models.AppleModel apple = new();
        apple.PlaceRandomly(width, height, snake.Coordinates);

        SnakeMVC.Controller.CommandController controller = new();
        SnakeMVC.View.DrawView view = new();

        var inputThread = new Thread(() => controller.StartListeningForCommands());
        inputThread.IsBackground = true;
        inputThread.Start();

        while (true)
        {
            var req = controller.GetCurrentDirection();
            if (req != (0, 0))
            {
                snake.Move(req);
            }

            if (snake.CheckApple(apple.Coordinate)){
                apple.PlaceRandomly(width, height, snake.Coordinates);
            }

            field.InitializeGrid();
            foreach (var segment in snake.Coordinates)
            {
                field.Grid[segment.Item2, segment.Item1] = snakeSymbol;
            }

            field.Grid[apple.Coordinate.Item1, apple.Coordinate.Item2] = appleSymbol;

            view.Draw(field);
            Console.WriteLine(apple.Coordinate);
            Thread.Sleep(500);
        }
    }
}
