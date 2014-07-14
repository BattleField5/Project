namespace BattleField
{
    using System;
    using System.Linq;
    using System.Collections.Generic;

    public class Gameboard : IGameboard
    {
        //private const double LowerBoundMines = 0.15;
        //private const double UpperBoundMines = 0.3;
        //private readonly IRandomGenerator rand = RandomGenerator.Instance;
        private static IGameboard gameboard = null;
        private Cell[,] field = null;
        private int minesCount = 0;
        private int size = 0;

        protected Gameboard(int size)
        {
            var feildGenerator = new FieldGenerator();
            this.Size = size;
            this.Field = feildGenerator.GenerateField(this.Size);
        }

        public static IGameboard Initialize(int size)
        {
            if (gameboard == null)
            {
                gameboard = new Gameboard(size);
            }
            return gameboard;
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

    }
}
