using Day2;

namespace UnitTests.Days;

[TestClass]
public class Day2Tests
{
    [TestMethod]
    public void TestPart1()
    {
        const string input = """
                             11-22,95-115,998-1012,1188511880-1188511890,222220-222224,
                             1698522-1698528,446443-446449,38593856-38593862,565653-565659,
                             824824821-824824827,2121212118-2121212124
                             """;

        var part1 = Challenges.Part1(input);

        Assert.AreEqual(1227775554L, part1);
    }

    [TestMethod]
    public void TestPart2()
    {
        const string input = """
                             11-22,95-115,998-1012,1188511880-1188511890,222220-222224,
                             1698522-1698528,446443-446449,38593856-38593862,565653-565659,
                             824824821-824824827,2121212118-2121212124
                             """;

        var part2 = Challenges.Part2(input);

        Assert.AreEqual(4174379265L, part2);
    }
}