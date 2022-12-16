namespace AoC.Apps.Day3;

static class Extensions
{
    public static int GetPriority(this char chr) {
        if (char.IsLower(chr)) {
            var startIndex = 'a' - 1;
            return chr - startIndex;
        }
        else if (char.IsUpper(chr)) {
            var startIndx = 'A' - 27;
            return chr - startIndx;
        }
        else {
            throw new ArgumentException($"Unsupported character: {chr}", nameof(chr));
        }
    }
}
