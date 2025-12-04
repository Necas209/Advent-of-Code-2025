using System.Collections.Immutable;
using System.Text;

namespace Day3;

public static class Challenges
{
    public readonly record struct Bank(ImmutableArray<int> Batteries);

    public static IEnumerable<Bank> ExtractBanks(IEnumerable<string> data)
    {
        return data
            .Select(line => line
                .Select(c => (int)char.GetNumericValue(c))
                .ToImmutableArray()
            )
            .Select(arr => new Bank(arr));
    }

    public static long Part1(IReadOnlyCollection<Bank> banks) => Compute(banks, 2);

    public static long Part2(IReadOnlyCollection<Bank> banks) => Compute(banks, 12);

    private static long Compute(IEnumerable<Bank> banks, int n) => banks.Select(bank => FindMax(bank, n)).Sum();

    private static long FindMax(Bank bank, int n)
    {
        var batteries = bank.Batteries;
        if (n == batteries.Length)
            return long.Parse(string.Join("", batteries));

        var resultBuilder = new StringBuilder();
        var currentStartIndex = 0;
        var remainingToPick = n;

        while (remainingToPick > 0)
        {
            var searchWindowEnd = batteries.Length - (remainingToPick - 1);

            var maxBattery = -1;
            var maxBatteryFoundAtIndex = -1;

            for (var i = currentStartIndex; i < searchWindowEnd; i++)
            {
                var currentBattery = batteries[i];
                if (currentBattery <= maxBattery) continue;
                maxBattery = currentBattery;
                maxBatteryFoundAtIndex = i;
            }

            resultBuilder.Append(maxBattery);
            currentStartIndex = maxBatteryFoundAtIndex + 1;
            remainingToPick--;
        }

        return long.Parse(resultBuilder.ToString());
    }
}