using System;
using System.Collections.Generic;

namespace BattleField
{
    /// <summary>
    /// Can generate a gameboard.
    /// </summary>
    public class GameboardGenerator : IGameboardGenerator
    {
        private readonly IRandomGenerator rand;
        
        /// <summary>
        /// Creates a new instance of GameboardGenerator
        /// </summary>
        public GameboardGenerator(IRandomGenerator randomGenerator)
        {
            this.rand = randomGenerator;
        }

        /// <summary>
        /// Generates a gameboard
        /// </summary>
        /// <param name="size">Number of cells in width and height</param>
        public IGameboard Generate(int size, double minesPercentage)
        {
            IGameboard gameboard = new Gameboard(size);
            int minesCount = this.DetermineMineCount(size, minesPercentage);
            gameboard.MinesCount = minesCount;
            this.GenerateEmptyField(gameboard);
            this.GenerateMinesInField(gameboard, minesCount);
            
            return gameboard;
        }

        private void GenerateEmptyField(IGameboard gameboard)
        {
            int size = gameboard.Size;
            for (int row = 0; row < size; row++)
            {
                for (int col = 0; col < size; col++)
                {
                    gameboard[row, col] = new EmptyCell();
                }
            }
        }

        private void GenerateMinesInField(IGameboard gameboard, int minesCount)
        {
            int size = gameboard.Size;
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
                gameboard[cellX, cellY] = currentCell;
            }
        }

        private int DetermineMineCount(int size, double percentage)
        {
            double totalNumberOfCells = (double)size * size;
            int minesCount = (int)Math.Round(totalNumberOfCells * percentage);

            return minesCount;
        }
    }
}
