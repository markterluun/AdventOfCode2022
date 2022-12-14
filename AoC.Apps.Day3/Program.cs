﻿namespace AoC.Apps.Day3;

static class Program
{
    static void Main() {
        var input = File.ReadAllLines("input.txt");

        Day1(input);
    }

    static void Day1(IEnumerable<string> input) {
        var result = input
            .Select(GetCompartments)
            .Select(GetCommonCharacters)
            .AsString()
            .Select(GetPriority)
            .Sum();

        Console.WriteLine(result);
    }

    static string[] GetCompartments(string rucksack) => rucksack.Length % 2 == 0
        ? (new[] {
            rucksack[..(rucksack.Length / 2)],
            rucksack[(rucksack.Length / 2)..],
        })
        : throw new ArgumentException("Invalid amount of items: odd number.", nameof(rucksack));

    static string GetCommonCharacters(IEnumerable<string> compartments) => compartments
        .Select(c => c.AsEnumerable())
        .Aggregate((a, b) => a.Intersect(b))
        .AsString();

    public static int GetPriority(char chr) =>
        chr.GetPriority();
}
