namespace SnakeMVC.View
{
    public class Result
    {
        public static void Lose(uint score)
        {
            Console.Write("Game over!\nYour score: ");
            Console.WriteLine(score);
        }

        public static void Win(uint score)
        {
            Console.Write("You win!\nYour score: ");
            Console.WriteLine(score);
        }
    }
}