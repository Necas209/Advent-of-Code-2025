using Day8;

var input = File.ReadAllText("input.txt");

var part1 = Challenges.Part1(input, 1000);
Console.WriteLine($"Part 1: {part1}");

var part2 = Challenges.Part2(input);
Console.WriteLine($"Part 2: {part2}");