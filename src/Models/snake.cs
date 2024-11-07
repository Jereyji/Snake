using System;
using System.Collections.Generic;

namespace SnakeMVC.Models
{
    public class SnakeModel
    {
        public Queue<(int, int)> Coordinates { get; }
        private (int, int) direction;

        public SnakeModel()
        {
            Coordinates = new Queue<(int, int)>();
            Coordinates.Enqueue((1, 1));
            Coordinates.Enqueue((2, 1));
            Coordinates.Enqueue((3, 1));
            direction = (1, 0);
        }

        public bool CheckNextMove((int, int) nextMove, int width, int height)
        {
            if (direction.Item1 == 0 && nextMove.Item1 != 0 || direction.Item2 == 0 && nextMove.Item2 != 0)
            {
                direction = nextMove;
            }

            int nextY = Coordinates.Last().Item1 + direction.Item1;
            int nextX = Coordinates.Last().Item2 + direction.Item2;

            if (Coordinates.Contains((nextY, nextX)) ||
                nextX == -1 || nextX == width ||
                nextY == -1 || nextY == height)
            {
                return false;
            }

            return true;
        }

        public void Move()
        {
            Coordinates.Enqueue((Coordinates.Last().Item1 + direction.Item1, Coordinates.Last().Item2 + direction.Item2));
        }

        public bool CheckApple((int, int) appleCoordinate)
        {
            if (Coordinates.Last() == appleCoordinate)
            {
                return true;
            }
            else
            {
                Coordinates.Dequeue();
                return false;
            }
        }
    }
}
