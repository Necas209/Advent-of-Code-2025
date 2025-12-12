using System.Collections.Immutable;
using System.Drawing;

var part1 = await Part1();
Console.WriteLine($"Part 1: {part1}");

return;

async Task<int> Part1()
{
    var input = await File.ReadAllTextAsync("input.txt");
    var parts = input.Split("\n\n");

    var presentSizes = parts[..^1]
        .Select(s => s.Count('#'))
        .ToImmutableArray();

    var regions = parts[^1]
        .Split('\n')
        .Select(Region.Parse);

    return regions.Count(region =>
    {
        var areaNeeded = region.Counts
            .Select((count, i) => presentSizes[i] * count)
            .Sum();

        return areaNeeded <= region.Area;
    });
}

internal readonly record struct Region(Size Size, ImmutableArray<int> Counts)
{
    public int Area => Size.Width * Size.Height;

    public static Region Parse(string s)
    {
        var parts = s.Split(": ");
        var sizePart = parts[0];
        var xIdx = sizePart.IndexOf('x');

        var width = int.Parse(sizePart[..xIdx]);
        var height = int.Parse(sizePart[(xIdx + 1)..]);
        var size = new Size(width, height);

        var counts = parts[1]
            .Split(' ')
            .Select(int.Parse)
            .ToImmutableArray();

        return new Region(size, counts);
    }
}