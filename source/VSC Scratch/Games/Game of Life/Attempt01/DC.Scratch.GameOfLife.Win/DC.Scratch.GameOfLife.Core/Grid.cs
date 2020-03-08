using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace DC.Scratch.GameOfLife.Core
{
    public enum Neighbor
    {
        NorthWest,
        North,
        NorthEast,
        East,
        SouthEast,
        South,
        SouthWest,
        West
    }

    public class Grid : INotifyPropertyChanging, INotifyPropertyChanged
    {
        public int ColumnCount { get; private set; }
        public int RowCount { get; private set; }

        public ObservableCollection<Cell> Cells { get; private set; }

        private Grid(int rowCount, int columnCount )
        {
            ColumnCount = columnCount;
            RowCount = rowCount;

            var length = columnCount*rowCount;
            Cells = new ObservableCollection<Cell>(Enumerable.Range(0, length).Select(x=>new Cell()));
        }

        public Cell GetCell(int row, int column)
        {
            if(row>=RowCount || row < 0) throw new IndexOutOfRangeException(string.Concat("Reqested Row: ", row, ", Row Count: ", RowCount));
            if(column>=ColumnCount || column < 0) throw new IndexOutOfRangeException(string.Concat("Reqested Column: ", column, ", Column Count: ", ColumnCount));

            var cellIndex = row*ColumnCount + column;
            return Cells[cellIndex];
        }

        public Cell GetNeighbor(Cell cell, Neighbor neighbor)
        {
            if(cell==null) throw new ArgumentException("Cell cannot be null", "cell");

            var cellIndex = Cells.IndexOf(cell);

            var row = Convert.ToInt32(Math.Floor((double) cellIndex/ColumnCount));
            var column = cellIndex - row*ColumnCount;

            switch (neighbor)
            {
                case Neighbor.NorthWest:
                    row -= 1;
                    column -= 1;
                    break;

                case Neighbor.North:
                    row -= 1;
                    break;

                case Neighbor.NorthEast:
                    row -= 1;
                    column += 1;
                    break;

                case Neighbor.East:
                    column += 1;
                    break;
                case Neighbor.SouthEast:
                    row += 1;
                    column += 1;
                    break;

                case Neighbor.South:
                    row += 1;
                    break;

                case Neighbor.SouthWest:
                    row += 1;
                    column -= 1;
                    break;

                case Neighbor.West:
                    column -= 1;
                    break;
                default:
                    throw new ArgumentOutOfRangeException("neighbor");
            }

            if (row < 0 || row >= RowCount) return null;
            if (column < 0 || column >= ColumnCount) return null;

            return GetCell(row, column);
        }

        public IEnumerable<Cell> FindCellsNeighbours(Cell cell)
        {
            return Enum.GetValues(typeof (Neighbor))
                .Cast<Neighbor>()
              //  .AsParallel()
                .Select(neighbor => GetNeighbor(cell, neighbor))
                .Where(neighbor=>neighbor!=null);
        }

        public static Grid Initialize(int rowCount, int columnCount)
        {
            var grid = new Grid(rowCount, columnCount);

            //Parallel.ForEach(grid.Cells, cell => cell.Neighbors = new List<Cell>(grid.FindCellsNeighbours(cell)));

            foreach (var cell in grid.Cells)
                cell.Neighbors = new List<Cell>(grid.FindCellsNeighbours(cell));

            return grid;
        }

        public void AdvanceToNextGeneration()
        {
            var cellIsAliveNextGen = new bool[Cells.Count];
            for (int i = 0; i < Cells.Count; i++)
            {
                cellIsAliveNextGen[i] = Cells[i].IsLiveNextGeneration();
            }

            for (int i = 0; i < cellIsAliveNextGen.Length; i++)
            {
                Cells[i].IsAlive = cellIsAliveNextGen[i];
            }
        }

        #region Property Changing and Changed Events and Handlers

        public event PropertyChangingEventHandler PropertyChanging;

        private void RaisePropertyChanged(string propertyName)
        {
            var handler = PropertyChanging;
            if (handler == null) return;
            handler(this, new PropertyChangingEventArgs(propertyName));
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void RaisePropertyChanging(string propertyName)
        {
            var handler = PropertyChanged;
            if (handler == null) return;
            handler(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion    
    }
}