namespace AoC.Apps.Day8;

static class Program
{
    static void Main()
    {
        var input = File.ReadAllLines(".input.txt");
        Part1(input);
    }

    static void Part1(string[] input)
    {
        var grid = GetGrid(input);
        var visibleTrees = CountVisibleTrees(grid);

        Console.WriteLine(visibleTrees);
    }

    static int[,] GetGrid(string[] input)
    {
        var (w, h) = (input[0].Length, input.Length);
        var result = new int[w, h];

        var asciiOffset = (int)'0';
        for (var y = 0; y < h; y++)
        {
            for (var x = 0; x < w; x++)
            {
                var chr = input[y][x];
                result[y, x] = chr - asciiOffset;
            }
        }

        return result;
    }

    static int CountVisibleTrees(int[,] grid)
    {
        var result = 0;

        var (w, h) = (grid.GetLength(0), grid.GetLength(1));
        for (var y = 0; y < h; y++)
        {
            for (var x = 0; x < w; x++)
            {
                if (IsVisible(grid, x, y))
                {
                    result++;
                }
            }
        }

        return result;
    }

    static bool IsVisible(int[,] grid, int x, int y)
    {
        var (w, h) = (grid.GetLength(0), grid.GetLength(1));
        var target = grid[y, x];

        // Outer edge.
        if (x == 0 || x == w - 1 || y == 0 || y == h - 1) return true;

        // Inner trees.
        var visibleFromLeft = true;
        var visibleFromRight = true;
        var visibleFromTop = true;
        var visibleFromBottom = true;

        // Visible from left.
        for (var iX = 0; iX < x; iX++)
        {
            if (grid[y, iX] < target) continue;

            visibleFromLeft = false;
            break;
        }

        // Visible from right.
        for (var iX = x + 1; iX < w; iX++)
        {
            if (grid[y, iX] < target) continue;

            visibleFromRight = false;
            break;
        }

        // Visible from top.
        for (var iY = 0; iY < y; iY++)
        {
            if (grid[iY, x] < target) continue;

            visibleFromTop = false;
            break;
        }

        // Visible from bottom.
        for (var iY = y + 1; iY < h; iY++)
        {
            if (grid[iY, x] < target) continue;

            visibleFromBottom = false;
            break;
        }

        // Invisible.
        return visibleFromLeft || visibleFromRight || visibleFromTop || visibleFromBottom;
    }

    static bool New_IsVisible(int[,] grid, int x, int y)
    {
        var (w, h) = (grid.GetLength(0), grid.GetLength(1));
        var target = grid[y, x];

        // Outer edge.
        if (x == 0 || x == w - 1 || y == 0 || y == h - 1) return true;

        // Check row.
        var iX = 0;
        while (iX < w)
        {
            if (iX == x) return true;

            var current = grid[y, iX];
            if (current >= target) // Invisible from current direction.
            {
                if (iX < x)
                {
                    // Invisible from the left;
                    // skip past x to continue checking from the right.
                    iX = x + 1;
                    continue;
                }
                else
                {
                    // Invisible from the right;
                    // continue checking the column.
                    break;
                }
            }

            iX++;
        }

        // Check column.
        var iY = 0;
        while (iY < h)
        {
            if (iY == y) return true;

            var current = grid[iY, x];
            if (current >= target) // Invisible from current direction.
            {
                if (iY < y) // Invisible from the top.
                {
                    // Skip past y to continue checking from the bottom.
                    iY = y + 1;
                    continue;
                }
                else // Invisible from the bottom.
                {
                    return false;
                }
            }

            iY++;
        }

        // Visible.
        return true;
    }
}
