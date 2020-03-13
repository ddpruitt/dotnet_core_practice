using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;

namespace DC.SudokuSolver01
{
    internal class SudokuSolver01
    {
        [DebuggerDisplay("[{Location.X}, {Location.Y}] Quad [{Quadrant.X}, {Quadrant.Y}] : {Value}")]
        internal class Cell
        {
            public int Value { get; set; }

            public Point Location { get; set; }

            private Point _quadrant;
            public Point Quadrant
            {
                get
                {
                    if (_quadrant == Point.Empty)
                    {
                        _quadrant = new Point(Location.X / 3, Location.Y / 3);
                    }
                    return _quadrant;
                }
            }

            public List<int> PossibleValues { get; }

            public Cell(int value, int x, int y)
            {
                Location = new Point(x,y);
                Value = value;
                PossibleValues = new List<int>(Enumerable.Range(1, 9));
                if (value != 0) PossibleValues.RemoveAll(pv => !pv.Equals(value));
            }
        }

        internal List<Cell> SudokuPuzzle { get; private set; } = new List<Cell>();

        public SudokuSolver01(int[,] puzzle)
        {
            SudokuPuzzle.AddRange(
                Enumerable.Range(0, 9)
                .SelectMany(x => 
                    Enumerable.Range(0, 9), (x, y) => new Cell(puzzle[y, x], x, y)));

        }

        public void RemoveImpossibleValues(Cell cell)
        {
            switch (cell.PossibleValues.Count == 1)
            {
                case true when cell.PossibleValues[0].Equals(cell.Value):
                    return;

                case true when !cell.PossibleValues[0].Equals(cell.Value):
                    throw new ArgumentException($"The Value of the Cell {cell.Value} does not match the last remaining Possible Value {cell.PossibleValues[0]}");

                case false when cell.Value != 0:
                    cell.PossibleValues.RemoveAll(pv => pv != cell.Value);
                    return;
            }

            var rowColumnQuadrantValues = SudokuPuzzle
                .Where(sp => sp.Location.X == cell.Location.X || sp.Location.Y == cell.Location.Y || sp.Quadrant == cell.Quadrant)
                .Select(sp => sp.Value)
                .Distinct();

            cell.PossibleValues.RemoveAll(rowColumnQuadrantValues.Contains);

            if (cell.PossibleValues.Count() == 1) cell.Value = cell.PossibleValues[0];
        }

        internal void ConsoleWritePuzzle( string title, bool resetToTop = false)
        {
            var topRow = Console.CursorTop;

            if (!string.IsNullOrWhiteSpace(title)) Console.WriteLine($"\n- - - - - - - - - - - - -\n| {title}");

            for (int y = 0; y < 9; y++)
            {
                if (y % 3 == 0) Console.WriteLine($"- - - - - - - - - - - - -");

                var row = SudokuPuzzle
                    .Where(sp => sp.Location.Y == y)
                    .Select(sp => sp.Value)
                    .ToArray();

                Console.WriteLine($"| {row[0]:#;#;-} {row[1]:#;#;-} {row[2]:#;#;-} | {row[3]:#;#;-} {row[4]:#;#;-} {row[5]:#;#;-} | {row[6]:#;#;-} {row[7]:#;#;-} {row[8]:#;#;-} | ");
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

        internal static void ExampleToSolve01(int[,] puzzle)
        {
            var solver = new SudokuSolver01(puzzle);

            //Console.Clear();
            solver.ConsoleWritePuzzle("Initial Puzzle");

            for (int i = 0; i < 100; i++)
            {
                
                solver.SudokuPuzzle.ForEach(solver.RemoveImpossibleValues);

                solver.ConsoleWritePuzzle("Solving...", true);
            }

            //solver.ClearConsoleToBottom();
            solver.ConsoleWritePuzzle("First Pass");

            solver.ClearConsoleToBottom();

        }
    }
}
