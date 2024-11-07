namespace SnakeMVC.Pkg
{
    class Settings
    {
        public const int Width = 30;
        public const int Height = 10;
        public const int Speed = 450;
        public const uint AddingScore = 500;
        public const uint WinScore = Width * Height * AddingScore;
        public static readonly (int, int) MoveUp = (-1, 0);
        public static readonly (int, int) MoveDown = (1, 0);
        public static readonly (int, int) MoveLeft = (0, -1);
        public static readonly (int, int) MoveRight = (0, 1);
        public const char HorizontalBorder = '=';
        public const char VerticalBorder = '|';
        public const char SnakeSymbol = 'O';
        public const char AppleSymbol = '@';
    }
}
