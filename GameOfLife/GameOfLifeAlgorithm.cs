using GameOfLife.Enums;
using GameOfLife.ViewModels;
using System.Windows;

namespace GameOfLife
{
    /// <summary>
    /// Classe statique qui calcule les états des cellules d'une grille
    /// </summary>
    class GameOfLifeAlgorithm
    {
        /*===============================*\
        |*            Attributs          *|
        \*===============================*/
        private static Point[] neighborsPos = { new Point(1, 1), new Point(-1, -1), new Point(-1, 1), new Point(1, -1), new Point(0, 1), new Point(1, 0), new Point(0, -1), new Point(-1, 0) };

        /*===============================*\
        |*       Méthodes Publiques      *|
        \*===============================*/

        /// <summary>
        /// Calcule et applique le prochain état de la grille
        /// </summary>
        /// <param name="grid">Grille à modifier</param>
        public static void Update(Grid grid)
        {
            grid.Statistics.Iterations += 1;
            grid.Statistics.OldestCell = 0;

            PrepareNextValues(grid);
            ApplyNextValues(grid);
        }

        /*===============================*\
        |*        Méthodes Privées       *|
        \*===============================*/

        /// <summary>
        /// Applique le prochain état des cellues
        /// </summary>
        /// <param name="grid">Grille à modifier</param>
        private static void ApplyNextValues(Grid grid)
        {
            for(int y = 0; y < grid.Height; y++)
            {
                for(int x = 0; x < grid.Width; x++)
                {
                    grid[x, y].Apply();
                }
            }

            if (grid.Statistics.GreatestPopulation < grid.Statistics.Population)
                grid.Statistics.GreatestPopulation = grid.Statistics.Population;
            if (grid.Statistics.SmallestPopulation > grid.Statistics.Population)
                grid.Statistics.SmallestPopulation = grid.Statistics.Population;
        }

        /// <summary>
        /// Prépare le prochain état des cellules
        /// </summary>
        /// <param name="grid">Grille à modifier</param>
        private static void PrepareNextValues(Grid grid)
        {
            for(int y = 0; y < grid.Height; y++)
            {
                for(int x = 0; x < grid.Width; x++)
                {
                    grid[x, y].Prepare(GetCellNextValue(grid, x, y));
                }
            }
        }

        /// <summary>
        /// Calcule le prochain état de la cellule
        /// </summary>
        /// <param name="grid">Grille à modifier</param>
        /// <param name="x">Coordonée X de la cellule</param>
        /// <param name="y">Coordonée Y de la cellule</param>
        /// <returns>Le prochain état de la cellule</returns>
        private static CellState GetCellNextValue(Grid grid, int x, int y)
        {
            Cell[] neighbors = GetCellNeighbors(grid, x, y);
            int alive = 0;
            foreach(Cell neighbor in neighbors)
            {
                if (neighbor.State == CellState.Alive)
                    alive++;
            }

            switch(alive)
            {
                case 2:
                    return grid[x, y].State;
                case 3:
                    return (grid[x, y].State == CellState.Dead) ? CellState.Alive : grid[x, y].State;
                default:
                    return CellState.Dead;
            }
        }

        /// <summary>
        /// Retourne un tableau contenant tous les voisins d'une cellule
        /// </summary>
        /// <param name="grid">Grille à modifier</param>
        /// <param name="x">Coordonée X de la cellule</param>
        /// <param name="y">Coordonée Y de la cellule</param>
        /// <returns></returns>
        private static Cell[] GetCellNeighbors(Grid grid, int x, int y)
        {
            Cell[] neighbors = new Cell[8];
            int compteur = 0;
            foreach(Point pos in neighborsPos)
            {
                int neighborX = ((int)(x + pos.X)) % grid.Width;
                int neighborY = ((int)(y + pos.Y)) % grid.Height;

                if (neighborX < 0)
                    neighborX = grid.Width + neighborX;
                if (neighborY < 0)
                    neighborY = grid.Height + neighborY;

                neighbors[compteur++] = grid[neighborX, neighborY];
            }
            return neighbors;
        }
    }
}
