using BenchmarkDotNet.Running;
using Day11;

var input = File.ReadAllText("input.txt");
var connections = Challenges.Parse(input);

var part1 = Challenges.Part1(connections);
Console.WriteLine($"Part 1: {part1}");

var part2 = Challenges.Part2(connections);
Console.WriteLine($"Part 2: {part2}");

BenchmarkRunner.Run<Part2Benchmark>();