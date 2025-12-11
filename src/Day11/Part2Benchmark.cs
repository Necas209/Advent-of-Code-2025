using BenchmarkDotNet.Attributes;
using Connections = System.Collections.Generic.Dictionary<int, int[]>;

namespace Day11;

public class Part2Benchmark
{
    private Connections _connections = null!;

    [GlobalSetup]
    public void Setup()
    {
        var input = File.ReadAllText("input.txt");
        _connections = Challenges.Parse(input);
    }

    [Benchmark]
    public long Part2() => Challenges.Part2(_connections);
}