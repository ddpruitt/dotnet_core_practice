using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DC.Scratch.GameOfLife.Core;

namespace DC.Scratch.GameOfLife.Con
{
    class Program
    {
        static void Main(string[] args)
        {
            var grid = Grid.Initialize(10, 10);

            // Seed Cells
            grid.Cells[42].IsAlive = true;
            grid.Cells[43].IsAlive = true;
            grid.Cells[44].IsAlive = true;
            
            grid.Cells[38].IsAlive = true;
            grid.Cells[48].IsAlive = true;
            grid.Cells[58].IsAlive = true;

            WriteGridToFile(grid);
            grid.AdvanceToNextGeneration();
            WriteGridToFile(grid);

        }

        private static void WriteGridToFile(Grid grid)
        {
            using (var file = File.AppendText("cell neighbors.txt"))
            {
                file.WriteLine(new string('=', 50));
                file.WriteLine(new string('*', 50));

                foreach (var cell in grid.Cells.Where(c => c.IsAlive))
                {
                    file.WriteLine(new string('=', 25));
                    file.WriteLine("Cell Index: {0}", grid.Cells.IndexOf(cell));
                    file.WriteLine("Cell IsAlive: {0}", cell.IsAlive);
                    file.WriteLine("Cell IsAliveNextGeneration: {0}", cell.IsLiveNextGeneration());
                    file.WriteLine(new string('-', 10));
                    foreach (var neighbor in cell.Neighbors)
                    {
                        file.WriteLine("Cell Neighbor Index: {0}", grid.Cells.IndexOf(neighbor));
                    }
                }
                file.Close();
            }
        }
    }
}
