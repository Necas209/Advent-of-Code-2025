using Day4;

var input = File.ReadAllLines("input.txt");
var grid = Grid.Parse(input);

var part1 = Challenges.Part1(grid);
Console.WriteLine($"Part 1: {part1}");

var part2 = Challenges.Part2(grid);
Console.WriteLine($"Part 2: {part2}");