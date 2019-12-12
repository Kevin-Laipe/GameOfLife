﻿using GameOfLife.Models;
using System.Windows;

namespace GameOfLife
{
    class GameOfLifeAlgorithm
    {
        private static Point[] neighborsPos = { new Point(1, 1), new Point(-1, -1), new Point(-1, 1), new Point(1, -1), new Point(0, 1), new Point(1, 0), new Point(0, -1), new Point(-1, 0) };

        public static void Update(Models.Grid grid)
        {
            Models.Cell.CellState[,] nextValues = PrepareNextValues(grid);
            ApplyNextValues(grid, nextValues);
        }

        private static void ApplyNextValues(Grid grid, Cell.CellState[,] values)
        {
            for(int y = 0; y < grid.Height; y++)
            {
                for(int x = 0; x < grid.Width; x++)
                {
                    grid[x, y].State = values[x, y];
                }
            }
        }

        private static Cell.CellState[,] PrepareNextValues(Grid grid)
        {
            Cell.CellState[,] nextValues = new Cell.CellState[grid.Width, grid.Height];

            for(int y = 0; y < grid.Height; y++)
            {
                for(int x = 0; x < grid.Width; x++)
                {
                    nextValues[x, y] = GetCellNextValue(grid, x, y);
                }
            }

            return nextValues;
        }

        private static Cell.CellState GetCellNextValue(Grid grid, int x, int y)
        {
            Cell[] neighbors = GetCellNeighbors(grid, x, y);
            int alive = 0;
            foreach(Cell neighbor in neighbors)
            {
                if (neighbor.State == Cell.CellState.Alive)
                    alive++;
            }

            switch(alive)
            {
                case 2:
                    return grid[x, y].State;
                case 3:
                    return (grid[x, y].State == Cell.CellState.Dead) ? Cell.CellState.Alive : grid[x, y].State;
                default:
                    return Cell.CellState.Dead;
            }
        }

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