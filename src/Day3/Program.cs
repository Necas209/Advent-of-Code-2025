using System.Collections.Immutable;
using Day3;

var data = File.ReadLines("input.txt");
var banks = Challenges.ExtractBanks(data).ToImmutableArray();

Console.WriteLine($"First Challenge: {Challenges.Part1(banks)}");
Console.WriteLine($"Second Challenge: {Challenges.Part2(banks)}");