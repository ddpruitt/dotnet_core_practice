using System;
using System.Collections.Generic;
using System.Text;

namespace DC.SudokuSolver01
{
    static class PuzzleConsoleWriter
    {
        //internal static void ConsoleWritePuzzle(ICollection<int> puzzle, string title, bool resetToTop = false)
        //{
        //    var topRow = Console.CursorTop;

        //    if (!string.IsNullOrWhiteSpace(title)) Console.WriteLine($"\n- - - - - - - - - - - - -\n| {title}");

        //    for (int y = 0; y < 9; y++)
        //    {
        //        if (y % 3 == 0) Console.WriteLine($"- - - - - - - - - - - - -");

        //        var row = puzzle[y]
        //            .Where(sp => sp.Location.Y == y)
        //            .Select(sp => sp.Value)
        //            .ToArray();

        //        Console.WriteLine($"| {row[0]:#;#;-} {row[1]:#;#;-} {row[2]:#;#;-} | {row[3]:#;#;-} {row[4]:#;#;-} {row[5]:#;#;-} | {row[6]:#;#;-} {row[7]:#;#;-} {row[8]:#;#;-} | ");
        //    }
        //    Console.WriteLine($"- - - - - - - - - - - - -");

        //    if (resetToTop) Console.SetCursorPosition(0, topRow);
        //}

        internal static void ConsoleWriteGrid(int[,] puzzle, string title, bool resetToTop = false)
        {
            var topRow = Console.CursorTop;

            if (!string.IsNullOrWhiteSpace(title)) Console.WriteLine($"\n- - - - - - - - - - - - -\n| {title}");

            for (int y = 0; y < 9; y++)
            {
                if (y % 3 == 0) Console.WriteLine($"- - - - - - - - - - - - -");
                Console.WriteLine($"| {puzzle[y, 0]:#;#;-} {puzzle[y, 1]:#;#;-} {puzzle[y, 2]:#;#;-} | {puzzle[y, 3]:#;#;-} {puzzle[y, 4]:#;#;-} {puzzle[y, 5]:#;#;-} | {puzzle[y, 6]:#;#;-} {puzzle[y, 7]:#;#;-} {puzzle[y, 8]:#;#;-} | ");
            }
            Console.WriteLine($"- - - - - - - - - - - - -");

            if (resetToTop) Console.SetCursorPosition(0, topRow);
        }

        internal static void ClearConsoleToBottom()
        {
            var topRow = Console.CursorTop;
            for (int i = topRow; i < topRow + 100; i++)
            {
                Console.SetCursorPosition(0, i);
                Console.Write(new string(' ', Console.WindowWidth));
            }
            Console.SetCursorPosition(0, topRow);
        }
    }
}
