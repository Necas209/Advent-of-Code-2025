using Connections = System.Collections.Generic.Dictionary<int, int[]>;

namespace Day11;

internal class PathFinder(Connections connections)
{
    private readonly Dictionary<(int Start, int End), long> _memo = new();
    private readonly int _encodedOut = "out".Encode();

    public long Count(int start, int end)
    {
        var key = (start, end);
        if (_memo.TryGetValue(key, out var count))
            return count;

        if (start == _encodedOut)
            return 0L;

        var outputs = connections[start];
        return _memo[key] = outputs.Contains(end)
            ? 1L
            : outputs.Sum(output => Count(output, end));
    }
}

internal record struct Connection(int Input, int[] Outputs)
{
    public static Connection Parse(string s)
    {
        var parts = s.Split(": ");
        var input = parts[0].Encode();
        var outputs = parts[1]
            .Split(' ')
            .Select(Extensions.Encode)
            .ToArray();
        return new Connection(input, outputs);
    }
}

public static class Extensions
{
    extension(string s)
    {
        public int Encode()
        {
            var val1 = s[0] - 'a';
            var val2 = s[1] - 'a';
            var val3 = s[2] - 'a';

            return val1 * 26 * 26 + val2 * 26 + val3;
        }
    }
}

public static class Challenges
{
    public static Connections Parse(string input)
    {
        return input
            .Split(Environment.NewLine)
            .Select(Connection.Parse)
            .ToDictionary(connection => connection.Input, connection => connection.Outputs);
    }

    public static long Part1(Connections connections)
    {
        var pathFinder = new PathFinder(connections);
        var you = "you".Encode();
        var @out = "out".Encode();
        return pathFinder.Count(you, @out);
    }

    public static long Part2(Connections connections)
    {
        var finder = new PathFinder(connections);

        var svr = "svr".Encode();
        var fft = "fft".Encode();
        var dac = "dac".Encode();
        var @out = "out".Encode();

        return finder.Count(svr, fft) * finder.Count(fft, dac) * finder.Count(dac, @out)
               + finder.Count(svr, dac) * finder.Count(dac, fft) * finder.Count(fft, @out);
    }
}