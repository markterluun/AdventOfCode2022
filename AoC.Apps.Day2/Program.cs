namespace AoC.Apps.Day2;

static class Program
{
    static void Main() {
        var input = File.ReadAllLines("input.txt");

        var score = 0;
        foreach (var line in input) {
            var other = line.First().ToHand();
            var you = line.Last().ToHand();

            score += RockPaperScissors.Play(you, other);
        }
        Console.WriteLine(score);
    }
}
