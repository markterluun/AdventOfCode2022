namespace AoC.Apps.Day2;

static class Program
{
    static void Main() {
        var input = File.ReadAllLines("input.txt");

        var score = 0;
        foreach (var line in input) {
            var other = line.First().ToHand();
            var strategy = line.Last().ToOutcome();
            var you = strategy.ToHand(other);

            Console.WriteLine($"{other,-12}{strategy,-8}{you}");

            score += RockPaperScissors.Play(you, other);
        }
        Console.WriteLine(score);
    }
}
