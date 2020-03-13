using System;

namespace DC.SudokuSolver01
{
    public class SudokuSolverUsingRecursion
    {
        /// <summary>
        /// An example solver to run, should get two possible solutions.
        /// </summary>
        internal static void ExampleToSolve01(int[,] puzzle)
        {
            var solver = new SudokuSolverUsingRecursion();

            //Console.Clear();
            solver.ConsoleWriteGrid(puzzle, "Initial Puzzle");

            solver.Solve(ref puzzle);

            //solver.ClearConsoleToBottom();
        }

        internal bool IsPossible(int y, int x, int n, int[,] grid)
        {
            for (int i = 0; i < 9; i++)
                if (grid[y, i] == n) return false;

            for (int i = 0; i < 9; i++)
                if (grid[i, x] == n) return false;

            var x0 = (x / 3) * 3;
            var y0 = (y / 3) * 3;

            for (int i = 0; i < 3; i++)
                for (int j = 0; j < 3; j++)
                    if (grid[y0 + i, x0 + j] == n) return false;

            return true;
        }

        public void Solve(ref int[,] grid)
        {
            for (int y = 0; y < 9; y++)
                for (int x = 0; x < 9; x++)
                {
                    if (grid[y, x] != 0) continue;
                    for (int n = 1; n <= 9; n++)
                    {
                        if (!IsPossible(y, x, n, grid)) continue;

                        grid[y, x] = n;

                        ConsoleWriteGrid(grid, "Searching...", true);

                        Solve(ref grid);
                        // If you get to this point then all attempts to solve the 
                        // puzzle with the value of n failed.  Reset it to zero
                        // and try again with the next number.
                        grid[y, x] = 0;
                    }

                    // If you get to this point then all possible attempts failed.  
                    return;
                }

            // If you get to this point then you found a working solution.
            // Print it out and find some more solutions.
            // The recursion will allow for finding multiple solutions.
            ConsoleWriteGrid(grid, "Possible Solution:");
        }

        internal void ConsoleWriteGrid(int[,] grid, string title, bool resetToTop = false)
        {
            var topRow = Console.CursorTop;

            if (!string.IsNullOrWhiteSpace(title)) Console.WriteLine($"\n- - - - - - - - - - - - -\n| {title}");

            for (int y = 0; y < 9; y++)
            {
                if (y % 3 == 0) Console.WriteLine($"- - - - - - - - - - - - -");
                Console.WriteLine($"| {grid[y, 0]:#;#;-} {grid[y, 1]:#;#;-} {grid[y, 2]:#;#;-} | {grid[y, 3]:#;#;-} {grid[y, 4]:#;#;-} {grid[y, 5]:#;#;-} | {grid[y, 6]:#;#;-} {grid[y, 7]:#;#;-} {grid[y, 8]:#;#;-} | ");
            }
            Console.WriteLine($"- - - - - - - - - - - - -");

            if (resetToTop) Console.SetCursorPosition(0, topRow);
        }

        internal void ClearConsoleToBottom()
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