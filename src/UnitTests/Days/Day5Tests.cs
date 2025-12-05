using Day5;

namespace UnitTests.Days;

[TestClass]
public class Day5Tests
{
    [TestMethod]
    public void TestPart1()
    {
        const string input = """
                             3-5
                             10-14
                             16-20
                             12-18

                             1
                             5
                             8
                             11
                             17
                             32
                             """;

        var result = Challenges.Part1(input);
        Assert.AreEqual(3, result);
    }
    
    [TestMethod]
    public void TestPart2()
    {
        const string input = """
                             3-5
                             10-14
                             16-20
                             12-18

                             1
                             5
                             8
                             11
                             17
                             32
                             """;

        var result = Challenges.Part2(input);
        Assert.AreEqual(14, result);
    }
}