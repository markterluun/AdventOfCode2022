namespace AoC.Apps.Day5;

static class Extensions
{
    public static string AsString<T>(this IEnumerable<T> values) =>
        values.Aggregate(string.Empty, (a, b) => a + b);

    public static void Push<T>(this Stack<T> stack, IEnumerable<T> values) {
        foreach (var item in values) {
            stack.Push(item);
        }
    }

    public static IEnumerable<T> Pop<T>(this Stack<T> stack, int amount) {
        for (var i = 0; i < amount; i++) {
            if (stack.TryPop(out var value)) {
                yield return value;
            }
            else {
                yield break;
            }
        }
    }
}
