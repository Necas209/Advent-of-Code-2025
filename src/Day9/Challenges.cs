using System.Collections.Immutable;
using System.Drawing;
using DotNetExtensions.Collections;
using SkiaSharp;

namespace Day9;

public static class Challenges
{
    extension(Point)
    {
        private static Point Parse(ReadOnlySpan<char> s)
        {
            var index = s.IndexOf(',');
            var x = int.Parse(s[..index]);
            var y = int.Parse(s[(index + 1)..]);
            return new Point(x, y);
        }
    }

    public static long Part1(string input)
    {
        var points = input
            .Split(Environment.NewLine)
            .Select(line => Point.Parse(line))
            .ToImmutableArray();

        var area = points
            .Pairs()
            .Select(t =>
            {
                var (first, second) = t;
                long width = Math.Abs(first.X - second.X) + 1;
                long height = Math.Abs(first.Y - second.Y) + 1;
                return width * height;
            })
            .Max();

        return area;
    }

    public static long Part2(string input)
    {
        // Parse points
        var points = input
            .Split(Environment.NewLine)
            .Select(line => Point.Parse(line))
            .ToImmutableArray();

        var path = new SKPath();
        var skPoints = points
            .Select(p => new SKPoint(p.X, p.Y))
            .ToArray();
        path.AddPoly(skPoints);
        var region = new SKRegion();
        region.SetPath(path);

        var area = points
            .Pairs()
            .Where(t =>
            {
                var (first, second) = t;
                var rect = new SKRectI(
                    Math.Min(first.X, second.X),
                    Math.Min(first.Y, second.Y),
                    Math.Max(first.X, second.X),
                    Math.Max(first.Y, second.Y)
                );
                return region.Contains(rect);
            })
            .Select(t =>
            {
                var (first, second) = t;
                long width = Math.Abs(first.X - second.X) + 1;
                long height = Math.Abs(first.Y - second.Y) + 1;
                return width * height;
            })
            .Max();

        return area;
    }
}