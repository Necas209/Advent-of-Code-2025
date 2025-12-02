using Day1;

namespace UnitTests.Days;

[TestClass]
public class Day1Tests
{
    [TestMethod]
    public void TestPart1()
    {
        const string input = """
                             L68
                             L30
                             R48
                             L5
                             R60
                             L55
                             L1
                             L99
                             R14
                             L82
                             """;

        var part1 = Challenges.Part1(input.Split(Environment.NewLine));

        Assert.AreEqual(3, part1);
    }

    [TestMethod]
    public void TestPart2()
    {
        const string input = """
                             L68
                             L30
                             R48
                             L5
                             R60
                             L55
                             L1
                             L99
                             R14
                             L82
                             """;

        var part2 = Challenges.Part2(input.Split(Environment.NewLine));

        Assert.AreEqual(6, part2);
    }
}