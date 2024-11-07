using System;
using System.Threading;
using SnakeMVC.Pkg;

namespace SnakeMVC.Main
{
    class Program
    {
        static void Main()
        {
            Controller.InputController controller = new();
            Domain.Game game = new(Settings.Width, Settings.Height);
            View.Field field = new(Settings.Width, Settings.Height);
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

                Thread.Sleep(Settings.Speed);
            }

            if (game.HasPlayerWon())
            {
                View.Result.Win(game.InfoScore.Score);
            }
            else
            {
                View.Result.Lose(game.InfoScore.Score);
            }
        }
    }
}

