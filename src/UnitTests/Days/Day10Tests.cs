using Day10;

namespace UnitTests.Days;

[TestClass]
public class Day10Tests
{
    [TestMethod]
    public void TestPart1()
    {
        const string input = """
                             [.##.] (3) (1,3) (2) (2,3) (0,2) (0,1) {3,5,4,7}
                             [...#.] (0,2,3,4) (2,3) (0,4) (0,1,2) (1,2,3,4) {7,5,12,7,2}
                             [.###.#] (0,1,2,3,4) (0,3,4) (0,1,2,4,5) (1,2) {10,11,11,5,10,5}
                             """;

        var part1 = Challenges.Part1(input);
        Assert.AreEqual(7, part1);
    }
    
    [TestMethod]
    public void TestPart2()
    {
        const string input = """
                             [.##.] (3) (1,3) (2) (2,3) (0,2) (0,1) {3,5,4,7}
                             [...#.] (0,2,3,4) (2,3) (0,4) (0,1,2) (1,2,3,4) {7,5,12,7,2}
                             [.###.#] (0,1,2,3,4) (0,3,4) (0,1,2,4,5) (1,2) {10,11,11,5,10,5}
                             """;

        var part2 = Challenges.Part2(input);
        Assert.AreEqual(33, part2);
    }
}