using System.Collections.Immutable;
using System.Globalization;
using System.Numerics;

namespace Day5;

public static class Challenges
{
    private readonly record struct Range<T>(T Start, T End) : IComparable<Range<T>> where T : INumber<T>
    {
        public bool Contains(T number) => number >= Start && number <= End;

        public bool Overlaps(Range<T> other) => End >= other.Start && Start <= other.End;

        public static Range<T> Parse(ReadOnlySpan<char> line)
        {
            var idx = line.IndexOf('-');
            var start = T.Parse(line[..idx], CultureInfo.CurrentCulture);
            var end = T.Parse(line[(idx + 1)..], CultureInfo.CurrentCulture);
            return new Range<T>(start, end);
        }

        public int CompareTo(Range<T> other)
        {
            return Start != other.Start ? Start.CompareTo(other.Start) : End.CompareTo(other.End);
        }
    }

    public static long Part1(string input)
    {
        var sections = input.Split("\n\n");
        var ranges = sections[0].Split('\n')
            .Where(line => !string.IsNullOrWhiteSpace(line))
            .Select(line => Range<long>.Parse(line))
            .ToImmutableArray();

        var numbers = sections[1].Split('\n')
            .Select(long.Parse)
            .ToImmutableArray();

        return numbers.Count(number => ranges.Any(range => range.Contains(number)));
    }

    public static long Part2(string input)
    {
        var sections = input.Split("\n\n");
        var ranges = sections[0].Split('\n')
            .Where(line => !string.IsNullOrWhiteSpace(line))
            .Select(line => Range<long>.Parse(line))
            .Order();

        var mergedRanges = new List<Range<long>>();
        foreach (var range in ranges)
        {
            if (mergedRanges.Count == 0 || !mergedRanges[^1].Overlaps(range))
            {
                mergedRanges.Add(range);
            }
            else
            {
                var last = mergedRanges[^1];
                mergedRanges[^1] = last with { End = Math.Max(last.End, range.End) };
            }
        }
        
        return mergedRanges.Sum(r => r.End - r.Start + 1);
    }
}