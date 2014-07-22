﻿using System;
using System.Collections.Generic;

namespace BattleField
{
    /// <summary>
    /// Can generate a gameboard.
    /// </summary>
    public class GameboardGenerator : IGameboardGenerator
    {
        private readonly double lowerBoundMines;
        private readonly double upperBoundMines;
        private readonly IRandomGenerator rand;
        
        /// <summary>
        /// Creates a new instance of GameboardGenerator
        /// </summary>
        public GameboardGenerator(double lowerBoundMines, double upperBoundMines, IRandomGenerator randomGenerator)
        {
            this.lowerBoundMines = lowerBoundMines;
            this.upperBoundMines = upperBoundMines;
            this.rand = randomGenerator;
        }

        /// <summary>
        /// Generates a gameboard
        /// </summary>
        /// <param name="size">Number of cells in width and height</param>
        public IGameboard Generate(int size)
        {
            var field = this.GenerateEmptyField(size);
            int minesCount = this.DetermineMineCount(size);
            field = this.GenerateMinesInField(field, minesCount, size);

            IGameboard gameboard = new Gameboard();
            gameboard.Size = size;
            gameboard.MinesCount = minesCount;
            gameboard.Field = field;

            return gameboard;
        }

        private Cell[,] GenerateEmptyField(int size)
        {
            var field = new Cell[size, size];
            for (int row = 0; row < size; row++)
            {
                for (int col = 0; col < size; col++)
                {
                    field[row, col] = new EmptyCell();
                }
            }

            return field;
        }

        private Cell[,] GenerateMinesInField(Cell[,] field, int minesCount, int size)
        {
            Array mineRadiusValues = Enum.GetValues(typeof(MineRadius));
            int mineRadiusMaxIndex = mineRadiusValues.Length - 1;

            List<Position> usedPositions = new List<Position>();
            while (usedPositions.Count < minesCount)
            {
                int cellX = this.rand.GetRandom(0, size - 1);
                int cellY = this.rand.GetRandom(0, size - 1);
                Position position = new Position(cellX, cellY);
                if (usedPositions.Contains(position))
                {
                    continue;
                }

                usedPositions.Add(position);
                int cellType = rand.GetRandom(0, mineRadiusMaxIndex);
                MineRadius randomRadius = (MineRadius)mineRadiusValues.GetValue(cellType);
                Cell currentCell = new Mine(randomRadius);
                field[cellX, cellY] = currentCell;
            }

            return field;
        }

        private int DetermineMineCount(int size)
        {
            double totalNumberOfCells = (double)size * size;
            int lowBound = (int)Math.Round(lowerBoundMines * totalNumberOfCells);
            int upperBound = (int)Math.Round(upperBoundMines * totalNumberOfCells);
            int minesCount = this.rand.GetRandom(lowBound, upperBound + 1);

            return minesCount;
        }
    }
}