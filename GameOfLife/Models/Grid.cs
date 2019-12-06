using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameOfLife.Models
{
    class Grid
    {
        private Cell[,] cells;
        private int height, width;

        public Grid(int width, int height)
        {
            this.width = width;
            this.height = height;

            cells = new Cell[width, height];
            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    cells[x, y] = new Cell();
                }
            }
        }

        public void Randomize()
        {
            Random random = new Random();
            foreach (Cell cell in cells)
            {
                cell.State = (Cell.CellState)random.Next(0, 1);
            }
        }

        public Cell this[int x, int y]
        {
            get { return cells[x, y]; }
            set { cells[x, y] = value; }
        }

        public int Width
        {
            get { return width; }
        }

        public int Height
        {
            get { return height; }
        }

    }
}
