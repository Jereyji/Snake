

using SnakeMVC.Pkg;

namespace SnakeMVC.Controller
{
    public class InputController
    {
        private readonly TimeSpan pressInterval = TimeSpan.FromSeconds(0.2);
        private DateTime lastPressTime = DateTime.Now;
        public (int, int) CurrentDirection { get; set; } = Settings.MoveDown;
        public bool IsEnd { get; set; } = false;
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
                            CurrentDirection =  Settings.MoveUp;
                            break;
                        case ConsoleKey.S:
                            CurrentDirection =  Settings.MoveDown;
                            break;
                        case ConsoleKey.A:
                            CurrentDirection =  Settings.MoveLeft;
                            break;
                        case ConsoleKey.D:
                            CurrentDirection =  Settings.MoveRight;
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
