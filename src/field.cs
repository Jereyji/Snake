using System;
using System.Collections.Generic;

class Field
{
    private readonly int width;
    private readonly int height;
    private char[,] grid;
    // private int score;

    public Field(int width, int height)
    {
        this.width = width;
        this.height = height;
        grid = new char[height, width];
        InitializeGrid();
    }

    private void InitializeGrid()
    {
        for (int y = 0; y < height; y++)
        {
            for (int x = 0; x < width; x++)
            {
                grid[y, x] = ' ';
            }
        }
    }

    public void Draw(Queue<(int, int)> snake)
    {
        InitializeGrid();
        foreach (var segment in snake)
        {
            grid[segment.Item2, segment.Item1] = 'O';
        }

        Console.Clear();
        Console.WriteLine(new string('-', width));

        for (int y = 0; y < height; y++)
        {
            Console.Write('|');
            for (int x = 0; x < width; x++)
            {
                Console.Write(grid[y, x]);
            }
            Console.WriteLine('|');
        }

        Console.WriteLine(new string('-', width));
    }
}