using Day4;

namespace UnitTests.Days;

[TestClass]
public class Day4Tests
{
    [TestMethod]
    public void TestPart1()
    {
        const string input = """
                             ..@@.@@@@.
                             @@@.@.@.@@
                             @@@@@.@.@@
                             @.@@@@..@.
                             @@.@@@@.@@
                             .@@@@@@@.@
                             .@.@.@.@@@
                             @.@@@.@@@@
                             .@@@@@@@@.
                             @.@.@@@.@.
                             """;

        var grid = Grid.Parse(input.Split(Environment.NewLine));
        var total = Challenges.Part1(grid);

        Assert.AreEqual(13, total);
    }

    [TestMethod]
    public void TestPart2()
    {
        const string input = """
                             ..@@.@@@@.
                             @@@.@.@.@@
                             @@@@@.@.@@
                             @.@@@@..@.
                             @@.@@@@.@@
                             .@@@@@@@.@
                             .@.@.@.@@@
                             @.@@@.@@@@
                             .@@@@@@@@.
                             @.@.@@@.@.
                             """;

        var grid = Grid.Parse(input.Split(Environment.NewLine));
        var total = Challenges.Part2(grid);

        Assert.AreEqual(43, total);
    }
}