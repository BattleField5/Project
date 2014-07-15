using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleField
{
    public class FieldGenerator
    {
        private const double LowerBoundMines = 0.15;
        private const double UpperBoundMines = 0.3;
        private const int FirstCellTypeIndex = 1;
        private const int LastCellTypeIndex = 5;
        private readonly IRandomGenerator rand;
        public FieldGenerator()
        {
            rand = RandomGenerator.Instance;
        }

        public Cell[,] GenerateField(int size)
        {
            var field = GenerateEmptyField(size);
            int minesCount = DetermineMineCount(size, rand);
            field = GenerateMinesInField(field, minesCount, size, rand);
            return field;
        }

        private Cell[,] GenerateEmptyField(int size)
        {
            var field = new Cell[size, size];
            for (int row = 0; row < size; row++)
            {
                for (int col = 0; col < size; col++)
                {
                    field[row, col] = new Cell(row, col, false);
                }
            }

            return field;
        }

        private Cell[,] GenerateMinesInField(Cell[,] field, int minesCount, int size, IRandomGenerator rand)
        {
            List<Cell> mines = new List<Cell>();
            for (int counter = 0; counter < minesCount; counter++)
            {
                int cellX = rand.GetRandom(0, size);
                int cellY = rand.GetRandom(0, size);
                int cellType = rand.GetRandom(FirstCellTypeIndex, LastCellTypeIndex+1);
                Cell currentCell = new Cell(cellX, cellY, true, cellType);

                if (mines.Contains(currentCell))
                {
                    counter--;
                    continue;
                }

                mines.Add(currentCell);
                field[cellX, cellY] = currentCell;
            }

            return field;
        }

        private int DetermineMineCount(int size, IRandomGenerator rand)
        {
            double totalCells = (double)size * size;
            int lowBound = (int)(Math.Round(LowerBoundMines * totalCells));
            int upperBound = (int)(Math.Round(UpperBoundMines * totalCells));
            int minesCount = rand.GetRandom(lowBound, upperBound + 1);

            return minesCount;
        }
    }
}
