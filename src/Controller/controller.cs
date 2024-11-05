

namespace SnakeMVC.Controller
{
    public class CommandController
    {
        private (int, int) currentDirection = (1, 0);

        public void StartListeningForCommands()
        {
            while (true)
            {
                if (Console.KeyAvailable)
                {
                    ConsoleKeyInfo keyInfo = Console.ReadKey(true);

                    switch (keyInfo.Key)
                    {
                        case ConsoleKey.W:
                            currentDirection = (0, -1);
                            break;
                        case ConsoleKey.S:
                            currentDirection = (0, 1);
                            break;
                        case ConsoleKey.A:
                            currentDirection = (-1, 0);
                            break;
                        case ConsoleKey.D:
                            currentDirection = (1, 0);
                            break;
                        case ConsoleKey.Q:
                            Environment.Exit(0);
                            break;
                    }
                }
                Thread.Sleep(100);
            }
        }

        public (int, int) GetCurrentDirection()
        {
            return currentDirection;
        }
    }
}
