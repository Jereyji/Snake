using System;
using System.Collections.Generic;

class Snake
{
    private Queue<(int, int)> coordinates;
    private (int, int) curDirection = (0, 1);

    public Snake(Queue<(int, int)> coordinates)
    {
        this.coordinates = coordinates;
    }

    public Queue<(int, int)> Coordinates
    {
        get
        {
            return coordinates;
        }
    }

    public void Move((int, int) nextMove, bool bigger = false)
    {
        if (curDirection.Item1 == 0 && nextMove.Item1 != 0 || curDirection.Item2 == 0 && nextMove.Item2 != 0)
        {
            curDirection.Item1 = nextMove.Item1;
            curDirection.Item2 = nextMove.Item2;
        }

        int nextX = coordinates.Last().Item1 + curDirection.Item1;
        int nextY = coordinates.Last().Item2 + curDirection.Item2;

        coordinates.Enqueue((nextX, nextY));
        if (!bigger)
        {
            coordinates.Dequeue();
        }
    }
}
