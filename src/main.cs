using System;
using System.Threading;

// NEED: realize MVC, visitor
// TODO: отрисовка поля
// TODO: считывание команд (w,a,s,d,q)
// TODO: рандомизация появления бонуса, если отсутствует на поле
// TODO: поедание бонуса -> увеличение змеи
// TODO: счетчик
// TODO: 

namespace SnakeMVC.Main
{
    class Program
    {
        const int width = 30;
        const int height = 10;
        const uint winScore = 100000;
        static void Main()
        {
            Controller.InputController controller = new();
            Domain.Game game = new(width, height);
            View.Field field = new(width, height);
            View.Result result = new();

            var inputThread = new Thread(() => controller.StartListeningForCommands())
            {
                IsBackground = true
            };

            inputThread.Start();

            while (!controller.IsEnd)
            {
                if (!game.Step(controller.CurrentDirection))
                {
                    break;
                }

                field.FillGrid(game.Snake.Coordinates, game.Apple.Coordinate);
                field.Draw(game.InfoScore.Score);

                Thread.Sleep(500);
            }

            if (game.InfoScore.Score == winScore)
            {
                result.Win(game.InfoScore.Score);
            }
            else
            {
                result.Lose(game.InfoScore.Score);
            }
        }
    }
}

