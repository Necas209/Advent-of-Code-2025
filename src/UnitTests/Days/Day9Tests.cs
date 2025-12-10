using Day9;

namespace UnitTests.Days;

[TestClass]
public class Day9Tests
{
    [TestMethod]
    public void TestPart1()
    {
        const string input = """
                             7,1
                             11,1
                             11,7
                             9,7
                             9,5
                             2,5
                             2,3
                             7,3
                             """;

        var result = Challenges.Part1(input);
        Assert.AreEqual(50, result);
    } 
    
    [TestMethod]
    public void TestPart2()
    {
        const string input = """
                             7,1
                             11,1
                             11,7
                             9,7
                             9,5
                             2,5
                             2,3
                             7,3
                             """;

        var result = Challenges.Part2(input);
        Assert.AreEqual(24, result);
    }
}