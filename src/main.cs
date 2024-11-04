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

    static void Main()
    {
        Queue<(int, int)> startSnakeCoordinates = new Queue<(int, int)>();
        startSnakeCoordinates.Enqueue((1, 1));
        startSnakeCoordinates.Enqueue((1, 2));
        startSnakeCoordinates.Enqueue((1, 3));

        Snake snake = new(startSnakeCoordinates);
        Field field = new(width, height);

        int counter = 0; // temp
        while (counter < 500)
        {
            snake.Move(GetCommandsFromConsole());

            field.Draw(snake.Coordinates);

            Console.Write($"\r{counter++}");
            Thread.Sleep(500);
        }
    }

    private static (int, int) GetCommandsFromConsole()
    {
        if (Console.KeyAvailable)
        {
            ConsoleKeyInfo keyInfo = Console.ReadKey(true);
            if (keyInfo.Key == ConsoleKey.W)
            {
                return (0, -1);
            }
            else if (keyInfo.Key == ConsoleKey.S)
            {
                return (0, 1);
            }
            else if (keyInfo.Key == ConsoleKey.A)
            {
                return (-1, 0);
            }
            else if (keyInfo.Key == ConsoleKey.D)
            {
                return (1, 0);
            }
        }
        return (0, 0);
    }
}
