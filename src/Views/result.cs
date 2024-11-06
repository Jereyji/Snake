namespace SnakeMVC.View
{
    public class Result
    {
        public void Lose(uint score)
        {
            Console.Write("Game over!\nYour score: ");
            Console.WriteLine(score);
        }

        public void Win(uint score)
        {
            Console.Write("You win!\nYour score: ");
            Console.WriteLine(score);
        }
    }
}