namespace BattleField
{
    using System;
    using System.Linq;
    using System.Collections.Generic;

    public class Gameboard
    {
        public const char FieldSymbol = '-';
        public const char DetonatedFieldSymbol = 'X';
        private const double LowerBoundMines = 0.15;
        private const double UpperBoundMines = 0.3;
        private static Gameboard instance = null;
        private Cell[,] field = null;
        private int minesCount = 0;
        private int size = 0;

        private Gameboard(int size)
        {
            this.Field = new Cell[size, size];
            this.Size = size;
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
            GenerateField();
            GenerateMines();          
        }

        private void GenerateField()
        {
            for (int row = 0; row < this.Size; row++)
            {
                for (int col = 0; col < this.Size; col++)
                {
                    this.Field[row, col] = new Cell(row, col, FieldSymbol);
                }
            }
        }

        private void GenerateMines()
        {
            DetermineMineCount();
            List<Cell> mines = new List<Cell>();
            for (int counter = 0; counter < this.MinesCount; counter++)
            {
                int cellX = GameServices.RandomGenerator.Next(0, this.Size);
                int cellY = GameServices.RandomGenerator.Next(0, this.Size);
                int cellType = GameServices.RandomGenerator.Next('1', '6');
                Cell currentCell = new Cell(cellX, cellY, Convert.ToChar(cellType));

                if (mines.Contains(currentCell))
                {
                    counter--;
                    continue;
                }

                mines.Add(currentCell);
                this.Field[cellX, cellY] = currentCell;
            }
        }

        private void DetermineMineCount()
        {
            double totalCells = (double)this.Size * this.Size;
            int lowBound = (int)(LowerBoundMines * totalCells);
            int upperBound = (int)(UpperBoundMines * totalCells);
            this.MinesCount = GameServices.RandomGenerator.Next(lowBound, upperBound);
        }
    }
}
