namespace Day1;

public static class Challenges
{
    public record struct Rotation(int Amount, int Direction)
    {
        public static Rotation Parse(ReadOnlySpan<char> s)
        {
            var clockwise = s[0] == 'R' ? 1 : -1;
            var amount = int.Parse(s[1..]);
            return new Rotation(amount, clockwise);
        }
    }

    public static int Part1(IEnumerable<string> lines)
    {
        var current = 50;
        var zeroCount = 0;

        foreach (var (amount, direction) in ExtractRotations(lines))
        {
            current = (current + amount * direction) % 100;
            if (current < 0)
            {
                current += 100;
            }
            if (current == 0)
            {
                zeroCount++;
            }
        }

        return zeroCount;
    }

    public static long Part2(IEnumerable<string> lines)
    {
        var current = 50;
        var zeroCount = 0L;

        foreach (var (amount, direction) in ExtractRotations(lines))
        {
            zeroCount += amount / 100;
            var rem = direction * (amount % 100);
            if (current != 0 && current + rem <= 0 || current + rem >= 100)
            {
                zeroCount++;
            }

            current = (current + amount * direction) % 100;
            if (current < 0)
            {
                current += 100;
            }
        }

        return zeroCount;
    }

    private static IEnumerable<Rotation> ExtractRotations(IEnumerable<string> lines)
    {
        return lines.Select(line => Rotation.Parse(line));
    }
}