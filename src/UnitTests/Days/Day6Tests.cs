using Day6;

namespace UnitTests.Days;

[TestClass]
public class Day6Tests
{
    [TestMethod]
    public void TestPart1()
    {
        const string input = """
                             123 328  51 64 
                              45 64  387 23 
                               6 98  215 314
                             *   +   *   +  
                             """;
        
        var result = Challenges.Part1(input.Split(Environment.NewLine));

        Assert.AreEqual(4277556, result);
    }

    [TestMethod]
    public void TestPart2()
    {
        const string input = """
                             123 328  51 64 
                              45 64  387 23 
                               6 98  215 314
                             *   +   *   +  
                             """;

        var result = Challenges.Part2(input.Split(Environment.NewLine));
        
        Assert.AreEqual(3263827, result);
    }
}