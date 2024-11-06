

namespace SnakeMVC.Controller
{
    public class InputController
    {
        private readonly TimeSpan pressInterval = TimeSpan.FromSeconds(0.2);
        private DateTime lastPressTime = DateTime.Now;
        public (int, int) CurrentDirection { get; set; }
        public bool IsEnd { get; set; }
        public InputController()
        {
            CurrentDirection = (1, 0);
            IsEnd = false;
        }
        public void StartListeningForCommands()
        {
            while (true)
            {
                if (Console.KeyAvailable)
                {
                    DateTime currentPressTime = DateTime.Now;

                    if (currentPressTime - lastPressTime < pressInterval)
                    {
                        continue;
                    }

                    ConsoleKeyInfo keyInfo = Console.ReadKey(true);
                    lastPressTime = currentPressTime;

                    switch (keyInfo.Key)
                    {
                        case ConsoleKey.W:
                            CurrentDirection = (-1, 0);
                            break;
                        case ConsoleKey.S:
                            CurrentDirection = (1, 0);
                            break;
                        case ConsoleKey.A:
                            CurrentDirection = (0, -1);
                            break;
                        case ConsoleKey.D:
                            CurrentDirection = (0, 1);
                            break;
                        case ConsoleKey.Q:
                            IsEnd = true;
                            break;
                    }
                }
            }
        }
    }
}
