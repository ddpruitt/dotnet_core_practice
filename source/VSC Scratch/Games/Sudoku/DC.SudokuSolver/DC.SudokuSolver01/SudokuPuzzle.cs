using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;

namespace DC.SudokuSolver01
{
    public class SudokuPuzzle
    {
        public IEnumerable<Cell> ToList(int[,] puzzle)
        {
            var retList = Enumerable.Range(0, 9)
                .SelectMany(x =>
                    Enumerable.Range(0, 9), (x, y) => new Cell(puzzle[y, x], x, y));

            return retList;
        }

        public int[,] ToArray(IEnumerable<Cell> puzzle)
        {
            var puzzleGrouped = puzzle.GroupBy(pc => pc.Location.Y)
                .Select(pc => pc.ToArray())
                .ToArray();

            var returnValue = new int[9, 9];
            for (int y = 0; y < 9; y++)
            {
                for (int x = 0; x < 9; x++)
                {
                    returnValue[y, x] = puzzleGrouped[y][x].Value;
                }
            }

            return returnValue;
        }

        public void RemoveImpossibleValues(IEnumerable<Cell> puzzle, Cell cell)
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

            var rowColumnQuadrantValues = puzzle
                .Where(sp => sp.Location.X == cell.Location.X || sp.Location.Y == cell.Location.Y || sp.Quadrant == cell.Quadrant)
                .Select(sp => sp.Value)
                .Distinct();

            cell.PossibleValues.RemoveAll(rowColumnQuadrantValues.Contains);

            if (cell.PossibleValues.Count() == 1) cell.Value = cell.PossibleValues[0];
        }

        public bool IsValuePossible(IEnumerable<Cell> puzzle, int value, Cell cell)
        {
            return IsValuePossible(puzzle, value, cell.Location, cell.Quadrant);
        }
        
        public bool IsValuePossible(IEnumerable<Cell> puzzle, int value, int x, int y)
        {
            var location = new Point(x,y);
            var quadrant = new Point(x/3,y/3);

            return IsValuePossible(puzzle, value, location, quadrant);
        }

        public bool IsValuePossible(IEnumerable<Cell> puzzle, int value, Point location, Point quadrant)
        {
            var doesValueExist = puzzle
                .Where(sp => sp.Location.X == location.X || sp.Location.Y == location.Y || sp.Quadrant == quadrant)
                .Any(sp => sp.Value == value);

            return !doesValueExist;
        }

        public bool IsValuePossible(int[,] puzzle, int value, int row, int column)
        {
            for (int i = 0; i < 9; i++)
                if (puzzle[row, i] == value) return false;

            for (int i = 0; i < 9; i++)
                if (puzzle[i, column] == value) return false;

            var x0 = (column / 3) * 3;
            var y0 = (row / 3) * 3;

            for (int i = 0; i < 3; i++)
            for (int j = 0; j < 3; j++)
                if (puzzle[y0 + i, x0 + j] == value) return false;

            return true;
        }

        /// <summary>
        /// Solve the puzzle by removing impossible values
        /// </summary>
        /// <param name="puzzle"></param>
        /// <returns></returns>
        public IEnumerable<Cell> SolvePuzzle(IEnumerable<Cell> puzzle)
        {
            var solveMe = puzzle.ToList();
            int tryCount = 0;
            do
            {
                solveMe.ForEach(p => RemoveImpossibleValues(solveMe, p));
                tryCount++;
            } while (solveMe.Count(sm => sm.Value == 0) != 0 || tryCount < 50);

            return solveMe;
        }

        /// <summary>
        /// Solve the puzzle using recursion
        /// </summary>
        /// <param name="puzzle"></param>
        public void SolvePuzzle(ref int[,] puzzle)
        {
            for (int row = 0; row < 9; row++)
            for (int column = 0; column < 9; column++)
            {
                if (puzzle[row, column] != 0) continue;
                for (int n = 1; n <= 9; n++)
                {
                    if (!IsValuePossible(puzzle, n, row, column )) continue;

                    puzzle[row, column] = n;

                    //ConsoleWriteGrid(puzzle, "Searching...", true);

                    SolvePuzzle(ref puzzle);
                    // If you get to this point then all attempts to solve the 
                    // puzzle with the value of n failed.  Reset it to zero
                    // and try again with the next number.
                    puzzle[row, column] = 0;
                }

                // If you get to this point then all possible attempts failed.  
                return;
            }

            // If you get to this point then you found a working solution.
            // Print it out and find some more solutions.
            // The recursion will allow for finding multiple solutions.
            //ConsoleWriteGrid(puzzle, "Possible Solution:");
        }

        [DebuggerDisplay("[{Location.X}, {Location.Y}] Quad [{Quadrant.X}, {Quadrant.Y}] : {Value}")]
        public class Cell
        {
            public int Value { get; set; }

            public Point Location { get; }

            public Point Quadrant { get; }

            public List<int> PossibleValues { get; }

            public Cell(int value, int x, int y)
            {
                Location = new Point(x, y);
                Quadrant = new Point(x / 3, y / 3);

                Value = value;
                PossibleValues = new List<int>(Enumerable.Range(1, 9));
                if (value != 0) PossibleValues.RemoveAll(pv => !pv.Equals(value));
            }
        }
    }
}
