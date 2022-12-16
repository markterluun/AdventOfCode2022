using AoC.Shared;

namespace AoC.Apps.Day3;

static class Program
{
    static void Main() {
        var input = File.ReadAllLines("input.txt");

        Day1(input);
        Console.WriteLine();

        Day2(input);
        Console.WriteLine();
    }

    static void Day1(IEnumerable<string> input) {
        var result = input
            .Select(GetCompartments)
            .Select(e => e.Intersect().AsString())
            .AsString()
            .Select(GetPriority)
            .Sum();

        Console.WriteLine(result);
    }

    static void Day2(IEnumerable<string> input) {
        var result = input
            .Chunk(3)
            .Select(e => e.Intersect().AsString())
            .AsString()
            .Select(GetPriority)
            .Sum();

        Console.WriteLine(result);
    }

    // Utility methods

    static string[] GetCompartments(string rucksack) => rucksack.Length % 2 == 0
        ? (new[] {
            rucksack[..(rucksack.Length / 2)],
            rucksack[(rucksack.Length / 2)..],
        })
        : throw new ArgumentException("Invalid amount of items: odd number.", nameof(rucksack));

    public static int GetPriority(char chr) =>
        chr.GetPriority();
}
