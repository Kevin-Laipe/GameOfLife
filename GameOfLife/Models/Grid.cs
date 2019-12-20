using GameOfLife.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameOfLife.Models
{
    class Grid
    {
        /*===============================*\
        |*           Attributs           *|
        \*===============================*/
        private Cell[,] cells;
        private int height, width;

        /*===============================*\
        |*         Constructeurs         *|
        \*===============================*/

        public Grid(int width, int height)
        {
            this.width = width;
            this.height = height;

            this.InitCells(width, height);
        }

        /*===============================*\
        |*      Méthodes publiques       *|
        \*===============================*/

        public void Randomize()
        {
            Random random = new Random();
            foreach (Cell cell in cells)
            {
                cell.State = (CellState)random.Next(0, 2);
            }
        }

        public void Clear()
        {
            foreach(Cell cell in cells)
            {
                cell.State = CellState.Dead;
            }
        }

        /*===============================*\
        |*       Méthodes privées        *|
        \*===============================*/

        private void InitCells(int width, int height)
        {
            this.cells = new Cell[width, height];
            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    cells[x, y] = new Cell();
                }
            }
        }

        /*===============================*\
        |*           Accesseurs          *|
        \*===============================*/

        public Cell this[int x, int y]
        {
            get { return cells[x, y]; }
            set { cells[x, y] = value; }
        }

        public int Width
        {
            get { return width; }
            set { width = value; }
        }

        public int Height
        {
            get { return height; }
            set { height = value; }
        }
    }
}
