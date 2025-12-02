using Day2;

var content = File.ReadAllText("input.txt");

Console.WriteLine($"First Challenge: {Challenges.Part1(content)}");
Console.WriteLine($"Second Challenge: {Challenges.Part2(content)}");