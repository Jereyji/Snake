using System;
using System.Threading;

namespace SnakeMVC.Main
{
    class Program
    {
        const int width = 30;
        const int height = 10;
        const uint winScore = width * height * 500;
        static void Main()
        {
            Controller.InputController controller = new();
            Domain.Game game = new(width, height);
            View.Field field = new(width, height);
            View.Result result = new();

            var inputThread = new Thread(controller.StartListeningForCommands)
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

                Thread.Sleep(450);
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

