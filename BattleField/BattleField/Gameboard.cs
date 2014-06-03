namespace BattleField
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Gameboard
    {
        public const char FIELD_SYMBOL = '-';
        public const char DETONATED_FIELD_SYMBOL = 'X';
        private const double LOWER_BOUND_MINES = 0.15;
        private const double UPPER_BOUND_MINES = 0.3;
        private static Gameboard instance;
        private Cell[,] field = null;
        private int minesCount = 0;
        private int size = 0;

        private Gameboard(int size)
        {
            this.Field = new Cell[size, size];
            this.Size = size;
            DetermineMineCount();
            GenerateGameboard();
        }

        public static Gameboard Initialize(int size)
        {
            if (instance == null)
            {
                instance = new Gameboard(size);
            }
            return instance;
        }

        public Cell[,] Field
        {
            get { return this.field; }
            private set { this.field = value; }
        }

        public int MinesCount
        {
            get { return this.minesCount; }
            private set { this.minesCount = value; }
        }

        public int Size
        {
            get { return this.size; }
            private set { this.size = value; }
        }

        private void GenerateGameboard()
        {
            for (int i = 0; i < this.Size; i++)
            {
                for (int j = 0; j < this.Size; j++)
                {
                    Cell currentCell = new Cell(i, j);
                    currentCell.Value = FIELD_SYMBOL;
                    this.Field[i, j] = currentCell;
                }
            }

            List<Cell> mines = new List<Cell>();
            for (int i = 0; i < this.MinesCount; i++)
            {
                int cellX = GameServices.randomGenerator.Next(0, this.Size);
                int cellY = GameServices.randomGenerator.Next(0, this.Size);
                Cell newMine = new Cell(cellX, cellY);

                if (Contains(mines, newMine))
                {
                    i--;
                    continue;
                }

                int cellType = GameServices.randomGenerator.Next('1', '6');
                this.Field[cellX, cellY].Value = Convert.ToChar(cellType);
            }
        }

        private void DetermineMineCount()
        {
            double fields = (double)this.Size * this.Size;
            int lowBound = (int)(LOWER_BOUND_MINES * fields);
            int upperBound = (int)(UPPER_BOUND_MINES * fields);

            this.MinesCount = GameServices.randomGenerator.Next(lowBound, upperBound);
        }

        private static bool Contains(List<Cell> list, Cell mine)
        {
            return list.Contains(mine);
        }

    }
}
