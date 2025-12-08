using System.Globalization;
using System.Numerics;
using DotNetExtensions.Collections;

namespace Day8;

public static class Challenges
{
    public readonly record struct Point3D<T>(T X, T Y, T Z) where T : INumber<T>
    {
        public static Point3D<T> Parse(string s)
        {
            var parts = s.Split(',');
            return new Point3D<T>(
                T.Parse(parts[0], CultureInfo.InvariantCulture),
                T.Parse(parts[1], CultureInfo.InvariantCulture),
                T.Parse(parts[2], CultureInfo.InvariantCulture)
            );
        }

        public static T DistanceSquared(Point3D<T> a, Point3D<T> b) =>
            (a.X - b.X) * (a.X - b.X) +
            (a.Y - b.Y) * (a.Y - b.Y) +
            (a.Z - b.Z) * (a.Z - b.Z);
    }

    public static long Part1(string input, int maxPairs) => Algorithm(input, maxPairs).Part1;

    public static long Part2(string input) => Algorithm(input, int.MaxValue).Part2;

    private static (long Part1, long Part2) Algorithm(string input, int maxPairs)
    {
        var boxes = input
            .Split(Environment.NewLine)
            .Select(Point3D<long>.Parse)
            .ToList();

        var pairs = boxes
            .Pairs()
            .OrderBy(p => Point3D<long>.DistanceSquared(p.First, p.Second))
            .Take(maxPairs);

        var circuits = boxes
            .Select(b => new HashSet<Point3D<long>> { b })
            .ToList();

        long part2 = -1;
        foreach (var (first, second) in pairs)
        {
            var firstCircuit = circuits.FirstOrDefault(c => c.Contains(first));
            var secondCircuit = circuits.FirstOrDefault(c => c.Contains(second));

            HashSet<Point3D<long>> circuit;
            switch (firstCircuit, secondCircuit)
            {
                case (not null, not null):
                {
                    circuit = firstCircuit;
                    if (firstCircuit != secondCircuit)
                    {
                        firstCircuit.UnionWith(secondCircuit);
                        circuits.Remove(secondCircuit);
                    }

                    break;
                }
                case (not null, null):
                {
                    circuit = firstCircuit;
                    firstCircuit.Add(second);
                    break;
                }
                case (null, not null):
                {
                    circuit = secondCircuit;
                    secondCircuit.Add(first);
                    break;
                }
                case (null, null):
                {
                    circuit = [first, second];
                    circuits.Add(circuit);
                    break;
                }
            }

            if (circuit.Count != boxes.Count) continue;
            part2 = first.X * second.X;
            break;
        }

        var part1 = circuits
            .Select(circuit => circuit.Count)
            .OrderDescending()
            .Take(3)
            .Product();
        return (part1, part2);
    }
}