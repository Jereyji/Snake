using System;
using System.Collections.Generic;

namespace SnakeMVC.Models
{
    public class SnakeModel
    {
        public Queue<(int, int)> Coordinates { get; }
        public (int, int) Direction { get; set; }

        public SnakeModel()
        {
            Coordinates = new Queue<(int, int)>();
            Coordinates.Enqueue((1, 1));
            Coordinates.Enqueue((1, 2));
            Coordinates.Enqueue((1, 3));

            Direction = (0, 1);
        }

        public void Move((int, int) nextMove)
        {
            if (Direction.Item1 == 0 && nextMove.Item1 != 0 || Direction.Item2 == 0 && nextMove.Item2 != 0)
            {
                Direction = nextMove;
            }

            int nextX = Coordinates.Last().Item1 + Direction.Item1;
            int nextY = Coordinates.Last().Item2 + Direction.Item2;

            Coordinates.Enqueue((nextX, nextY));
        }

        public bool CheckApple((int, int) appleCoordinate)
        {
            if (Coordinates.Contains(appleCoordinate)) {
                return true;
            } else {
                Coordinates.Dequeue();
                return false;
            }
        }
    }
}
