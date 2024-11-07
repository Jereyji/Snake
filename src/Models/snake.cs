using System;
using System.Collections.Generic;
using SnakeMVC.Pkg;

namespace SnakeMVC.Models
{
    public class SnakeModel
    {
        public Queue<(int, int)> Coordinates;
        private (int, int) _direction = Settings.MoveDown;

        public SnakeModel()
        {
            Coordinates = new Queue<(int, int)>();
            Coordinates.Enqueue((1, 1));
            Coordinates.Enqueue((2, 1));
            Coordinates.Enqueue((3, 1));
        }

        public bool CanChangeDirection((int, int) newDirection)
        {
            return _direction.Item1 != -newDirection.Item1 || _direction.Item2 != -newDirection.Item2;
        }

        public void ChangeDirection((int, int) newDirection)
        {
            if (CanChangeDirection(newDirection))
            {
                _direction = newDirection;
            }
        }

        public bool CanMove(int width, int height)
        {
            var nextY = Coordinates.Last().Item1 + _direction.Item1;
            var nextX = Coordinates.Last().Item2 + _direction.Item2;

            return !(Coordinates.Contains((nextY, nextX)) || nextX < 0 || nextX >= width || nextY < 0 || nextY >= height);
        }

        public void Move()
        {
            var newHead = (Coordinates.Last().Item1 + _direction.Item1, Coordinates.Last().Item2 + _direction.Item2);
            Coordinates.Enqueue(newHead);
        }

        public bool HasEatenApple((int, int) appleCoordinate)
        {
            return Coordinates.Last() == appleCoordinate;
        }
    }
}
