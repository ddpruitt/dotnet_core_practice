using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;

namespace DC.Scratch.GameOfLife.Core
{
    [DebuggerDisplay("IsAlive={IsAlive}")]
    public class Cell : INotifyPropertyChanging, INotifyPropertyChanged
    {
        #region Property: IsAlive

        /// <summary>
        /// The <see cref="IsAlive" /> property's name.
        /// </summary>
        public const string IsAlivePropertyName = "IsAlive";

        private bool _isAlive;

        /// <summary>
        /// Sets and gets the IsAlive property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public bool IsAlive
        {
            get { return _isAlive; }

            set
            {
                if (_isAlive == value) return;

                RaisePropertyChanging(IsAlivePropertyName);
                _isAlive = value;
                RaisePropertyChanged(IsAlivePropertyName);
            }
        }

        #endregion

        public IList<Cell> Neighbors { get; set; }

        public Cell()
        {
            Neighbors = new List<Cell>();
            IsAlive = false;
        }

        public int CountOfLiveNeighbors()
        {
            return Neighbors.Count(n => n.IsAlive);
        }

        public bool IsLiveNextGeneration()
        {
            var liveNeighborCount = CountOfLiveNeighbors();

            // Any live cell with fewer than two live neighbours dies, as if caused by under-population.
            // Any live cell with more than three live neighbours dies, as if by overcrowding.
            if (IsAlive && (liveNeighborCount < 2 || liveNeighborCount > 3)) return false;

            // Any live cell with two or three live neighbours lives on to the next generation.
            if (IsAlive && (liveNeighborCount == 2 || liveNeighborCount == 3)) return true;

            // Any dead cell with exactly three live neighbours becomes a live cell, as if by reproduction.
            if (!IsAlive && liveNeighborCount == 3) return true;

            return false;
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
