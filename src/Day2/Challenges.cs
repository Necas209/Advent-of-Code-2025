using System.Collections;
using System.Text.RegularExpressions;
using DotNetExtensions.Core;

namespace Day2;

public static partial class Challenges
{
    public readonly record struct Range(long First, long Last) : IEnumerable<long>
    {
        public static Range Parse(ReadOnlySpan<char> part)
        {
            var idx = part.IndexOf('-');
            var first = long.Parse(part[..idx]);
            var last = long.Parse(part[(idx + 1)..]);
            return new Range(first, last);
        }

        public IEnumerator<long> GetEnumerator()
        {
            for (var i = First; i <= Last; i++)
                yield return i;
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }

    public static long Part1(string content)
    {
        var ranges = ExtractRanges(content);
        return ranges
            .SelectMany(range => range)
            .Where(id => id.NumberOfDigits() % 2 == 0)
            .Where(id =>
            {
                var (left, right) = id.Split();
                return left == right;
            })
            .Sum();
    }

    public static long Part2(string content)
    {
        var ranges = ExtractRanges(content);
        return ranges
            .SelectMany(range => range)
            .Where(id => MyRegex().IsMatch(id.ToString()))
            .Sum();
    }

    public static IEnumerable<Range> ExtractRanges(string content)
    {
        return content
            .Split(',', StringSplitOptions.TrimEntries)
            .Select(part => Range.Parse(part));
    }

    [GeneratedRegex(@"^(\d+)(?:\1)+$", RegexOptions.Compiled)]
    private static partial Regex MyRegex();
}