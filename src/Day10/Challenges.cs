using System.Collections.Immutable;
using DotNetExtensions.Collections;
using Google.OrTools.Sat;
using LinearExpr = Google.OrTools.Sat.LinearExpr;

namespace Day10;

public static class Challenges
{
    public record Machine(int Lights, ImmutableArray<int> Buttons)
    {
        public static Machine Parse(string line)
        {
            var parts = line.Split(' ');

            var lightsStr = string.Join("",
                parts[0][1..^1]
                    .Replace('.', '0')
                    .Replace('#', '1')
                    .Reverse()
            );
            var lights = Convert.ToInt32(lightsStr, 2);

            var buttons = parts[1..^1]
                .Select(part => part[1..^1]
                    .Split(',')
                    .Select(int.Parse)
                    .Sum(i => 1 << i))
                .ToImmutableArray();

            return new Machine(lights, buttons);
        }
    }

    public static int Part1(string input)
    {
        return input
            .Split(Environment.NewLine)
            .Select(Machine.Parse)
            .AsParallel()
            .Sum(machine =>
            {
                var presses = 1;
                while (machine.Buttons
                       .Combinations(presses)
                       .All(combo => combo.Xor() != machine.Lights))
                {
                    presses++;
                }

                return presses;
            });
    }

    public record Button(ImmutableArray<int> Indices);

    public record Machine2(ImmutableArray<Button> Buttons, ImmutableArray<int> Jolts)
    {
        public static Machine2 Parse(string line)
        {
            var parts = line.Split(' ');

            var jolts = parts[^1][1..^1]
                .Split(',')
                .Select(int.Parse)
                .ToImmutableArray();

            var buttons = parts[1..^1]
                .Select(part => part[1..^1]
                    .Split(',')
                    .Select(int.Parse)
                    .ToImmutableArray())
                .Select(arr => new Button(arr))
                .ToImmutableArray();

            return new Machine2(buttons, jolts);
        }
    }

    public static long Part2(string input)
    {
        return input
            .Split(Environment.NewLine)
            .Select(Machine2.Parse)
            .AsParallel()
            .Sum(SolveMachine);
    }

    private static long SolveMachine(Machine2 machine)
    {
        var (buttons, jolts) = machine;
        var model = new CpModel();

        var variables = new Dictionary<Button, IntVar>();
        foreach (var (idx, button) in buttons.Index())
        {
            var ub = button.Indices.Select(i => jolts[i]).Min();
            var variable = model.NewIntVar(0, ub, $"button{idx}");
            variables.Add(button, variable);
        }

        var counterToVars = jolts
            .Select((_, idx) => buttons
                .Where(b => b.Indices.Contains(idx))
                .Select(b => variables[b])
                .ToImmutableArray())
            .ToImmutableArray();

        foreach (var (i, jolt) in jolts.Index())
        {
            var vars = counterToVars[i];
            var constraint = vars.Length == 1
                ? vars[0] == jolt
                : LinearExpr.Sum(vars) == jolt;
            model.Add(constraint);
        }

        model.Minimize(LinearExpr.Sum(variables.Values));

        var solver = new CpSolver();
        solver.StringParameters = "num_search_workers:16";
        var status = solver.Solve(model);

        return status == CpSolverStatus.Optimal
            ? variables.Values.Select(solver.Value).Sum()
            : throw new InvalidOperationException("Machine could not be solved.");
    }
}