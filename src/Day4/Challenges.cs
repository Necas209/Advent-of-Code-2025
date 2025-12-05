using System.Drawing;
using DotNetExtensions.Core;

namespace Day4;

public static class Challenges
{
    public static int Part1(Grid grid)
    {
        var total = 0;
        for (var x = 0; x < grid.Width; x++)
        {
            for (var y = 0; y < grid.Height; y++)
            {
                var cell = new Point(x, y);
                if (grid[cell] && grid.IsAccessible(cell))
                {
                    total++;
                }
            }
        }

        return total;
    }
    
    public static int Part2(Grid grid)
    {
        var removed = 0;
        while (true)
        {
            var previous = removed;
            for (var x = 0; x < grid.Width; x++)
            {
                for (var y = 0; y < grid.Height; y++)
                {
                    var cell = new Point(x, y);
                    if (!grid[cell] || !grid.IsAccessible(cell)) continue;
                    grid.Cells[x, y] = false;
                    removed++;
                }
            }

            if (removed == previous)
            {
                return removed;
            }
        }
    }
}

public record Grid(int Width, int Height, bool[,] Cells)
{
    public static Grid Parse(string[] input)
    {
        var width = input[0].Length;
        var height = input.Length;
        var cells = new bool[width, height];
        for (var i = 0; i < width; i++)
        {
            for (var j = 0; j < height; j++)
            {
                cells[i, j] = input[j][i] == '@';
            }
        }

        return new Grid(width, height, cells);
    }

    public bool this[Point cell] => Cells[cell.X, cell.Y];

    private bool Exists(Point cell) => new Rectangle(0, 0, Width, Height).Contains(cell);

    public bool IsAccessible(Point cell)
    {
        var count = 0;

        var (left, right, top, bottom) = cell.GetNeighbors();
        var (topLeft, topRight, bottomLeft, bottomRight) = cell.GetCorners();

        if (Check(left)) count++;
        if (Check(right)) count++;
        if (Check(top)) count++;
        if (Check(bottom)) count++;
        if (Check(topLeft)) count++;
        if (Check(topRight)) count++;
        if (Check(bottomLeft)) count++;
        if (Check(bottomRight)) count++;

        return count < 4;
        bool Check(Point p) => Exists(p) && this[p];
    }
}