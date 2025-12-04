using System.Collections.Immutable;
using Day3;

namespace UnitTests.Days;

[TestClass]
public class Day3Tests
{
    private ImmutableArray<Challenges.Bank> _banks;

    [TestInitialize]
    public void SetupData()
    {
        const string input = """
                             987654321111111
                             811111111111119
                             234234234234278
                             818181911112111
                             """;

        var data = input.Split(Environment.NewLine);
        _banks = [..Challenges.ExtractBanks(data)];
    }

    [TestMethod]
    public void TestPart1()
    {
        var answer = Challenges.Part1(_banks);
        Assert.AreEqual(357, answer);
    }

    [TestMethod]
    public void TestPart2()
    {
        var answer = Challenges.Part2(_banks);
        Assert.AreEqual(3121910778619, answer);
    }
}