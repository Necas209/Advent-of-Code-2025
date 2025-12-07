using System.Drawing;

namespace Day7;

public static class Challenges
{
    public static int Part1(string[] input)
    {
        var start = input[0].IndexOf('S');
        var visited = new HashSet<Point>();
        Tachyon(new Point(start, 0));
        return visited.Count;

        void Tachyon(Point point)
        {
            while (point.Y != input.Length - 1)
            {
                var next = point with { Y = point.Y + 1 };
                if (input[next.Y][next.X] != '^')
                {
                    point = next;
                    continue;
                }

                if (!visited.Add(next)) return;
                Tachyon(next with { X = next.X - 1 });
                Tachyon(next with { X = next.X + 1 });
                return;
            }
        }
    }

    public static long Part2(string[] input)
    {
        var start = input[0].IndexOf('S');
        var visited = new Dictionary<Point, long>();
        return Tachyon(new Point(start, 0));

        long Tachyon(Point point)
        {
            while (point.Y != input.Length - 1)
            {
                var next = point with { Y = point.Y + 1 };
                if (input[next.Y][next.X] != '^')
                {
                    point = next;
                    continue;
                }

                if (visited.TryGetValue(next, out var splits)) return splits;

                splits += Tachyon(next with { X = next.X - 1 });
                splits += Tachyon(next with { X = next.X + 1 });
                visited.Add(next, splits);

                return splits;
            }

            return 1;
        }
    }
}