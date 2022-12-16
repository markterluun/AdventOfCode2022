namespace AoC.Shared;

public static partial class Extensions { }

// Array

partial class Extensions
{
    public static void Shift<T>(this T[] array, int amount, T replacement = default!)
    {
        if (amount == 0) return;

        var indice = Enumerable.Range(0, array.Length);

        if (amount > 0) // Shift right/down (0 --> 1, 1 --> 2 etc.)
        {
            indice = indice.Reverse().Skip(1);
            foreach (var index in indice)
            {
                array[index + 1] = array[index];
            }
            array[0] = replacement;
        }
        else // Amount < 0; shift left/up (2 --> 1, 1 --> 0 etc.)
        {
            indice = indice.Skip(1);
            foreach (var index in indice)
            {
                array[index - 1] = array[index];
            }
            array[^1] = replacement;
        }
    }
}

// IEnumerable

partial class Extensions
{
    public static bool None<T>(this IEnumerable<T> values) =>
        !values.Any();

    public static string AsString<T>(this IEnumerable<T> values) =>
        values.Aggregate(string.Empty, (a, b) => a + b);

    public static IEnumerable<T> Duplicates<T>(this IEnumerable<T> values) => values
        .GroupBy(e => e)
        .Where(g => g.Count() > 1)
        .Select(g => g.Key);

    public static IEnumerable<T> Intersect<T>(this IEnumerable<IEnumerable<T>> values) => values
        .Aggregate((a, b) => a.Intersect(b));
}

// Stack

partial class Extensions
{
    public static void Push<T>(this Stack<T> stack, IEnumerable<T> values, bool reverse = false)
    {
        if (reverse)
        {
            values = values.Reverse();
        }

        foreach (var item in values)
        {
            stack.Push(item);
        }
    }

    public static IEnumerable<T> Pop<T>(this Stack<T> stack, int amount)
    {
        for (var i = 0; i < amount; i++)
        {
            if (stack.TryPop(out var value))
            {
                yield return value;
            }
            else
            {
                yield break;
            }
        }
    }
}
