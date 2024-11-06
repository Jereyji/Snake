using System;
using System.Collections.Generic;

namespace SnakeMVC.Models
{
    public class SnakeModel
    {
        public Queue<(int, int)> Coordinates { get; }

        public SnakeModel()
        {
            Coordinates = new Queue<(int, int)>();
            Coordinates.Enqueue((1, 1));
            Coordinates.Enqueue((2, 1));
            Coordinates.Enqueue((3, 1));
        }

        public bool CheckNextMove((int, int) nextMove, int width, int height)
        {
            int nextY = Coordinates.Last().Item1 + nextMove.Item1;
            int nextX = Coordinates.Last().Item2 + nextMove.Item2;

            if (Coordinates.Contains((nextX, nextY)) ||
                nextX == -1 || nextX == width ||
                nextY == -1 || nextY == height)
            {
                return false;
            }

            return true;
        }

        public void Move((int, int) nextMove)
        {
            Coordinates.Enqueue((Coordinates.Last().Item1 + nextMove.Item1, Coordinates.Last().Item2 + nextMove.Item2));
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

        // private void CheckDirection((int, int) nextMove)
        // {
        //     if (CurrentDirection.Item1 == 0 && nextMove.Item1 != 0 || CurrentDirection.Item2 == 0 && nextMove.Item2 != 0)
        //     {
        //         CurrentDirection = nextMove;
        //     }
        // }
    }
}
