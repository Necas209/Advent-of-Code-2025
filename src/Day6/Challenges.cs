using System.Collections.Immutable;
using DotNetExtensions.Collections;

namespace Day6;

public static class Challenges
{
    public static long Part1(string[] input)
    {
        const StringSplitOptions options = StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries;

        var operations = input[^1]
            .Split(' ', options)
            .Select(char.Parse);

        var numbers = input[..^1]
            .Select(line => line
                .Split(' ', options)
                .Select(long.Parse)
                .ToImmutableArray())
            .ToImmutableArray();

        var total = 0L;
        foreach (var (i, operation) in operations.Index())
        {
            var current = numbers.Select(l => l[i]);
            switch (operation)
            {
                case '+':
                    total += current.Sum();
                    break;
                case '*':
                    total += current.Product();
                    break;
            }
        }

        return total;
    }

    public static long Part2(string[] input)
    {
        var numbers = input[..^1];
        numbers.AsSpan().Reverse();
        var length = input[0].Length;

        var total = 0L;
        var current = new List<long>();
        for (var idx = length - 1; idx >= 0; idx--)
        {
            var index = idx;
            var number = numbers
                .Select(n => n[index])
                .Where(c => c != ' ')
                .Select(char.GetNumericValue)
                .Select((d, i) => d * Math.Pow(10, i))
                .DefaultIfEmpty(-1)
                .Sum();
            if (number < 0)
                continue;
            
            current.Add((long)number);
            var operation = input[^1][idx];
            if (operation == ' ')
                continue;
            
            switch (operation)
            {
                case '+':
                    total += current.Sum();
                    break;
                case '*':
                    total += current.Product();
                    break;
            }
            current.Clear();
        }

        return total;
    }
}