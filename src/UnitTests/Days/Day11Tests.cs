using Day11;

namespace UnitTests.Days;

[TestClass]
public class Day11Tests
{
    [TestMethod]
    public void TestPart1()
    {
        const string input = """
                             aaa: you hhh
                             you: bbb ccc
                             bbb: ddd eee
                             ccc: ddd eee fff
                             ddd: ggg
                             eee: out
                             fff: out
                             ggg: out
                             hhh: ccc fff iii
                             iii: out
                             """;
        var connections = Challenges.Parse(input);

        var result = Challenges.Part1(connections);
        Assert.AreEqual(5, result);
    }
    
    [TestMethod]
    public void TestPart2()
    {
        const string input = """
                             svr: aaa bbb
                             aaa: fft
                             fft: ccc
                             bbb: tty
                             tty: ccc
                             ccc: ddd eee
                             ddd: hub
                             hub: fff
                             eee: dac
                             dac: fff
                             fff: ggg hhh
                             ggg: out
                             hhh: out
                             """;
        var connections = Challenges.Parse(input);

        var result = Challenges.Part2(connections);
        Assert.AreEqual(2, result);
    }
}