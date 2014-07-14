namespace BattleField
{
    using System;
    using System.Linq;
    using System.Collections.Generic;

    public class Gameboard : IGameboard
    {
        private static IGameboard gameboard = null;
        private Cell[,] field = null;
        private int minesCount = 0;
        private int size = 0;

        protected Gameboard(int size)
        {
            var fieldGenerator = new FieldGenerator();
            this.Size = size;
            this.Field = fieldGenerator.GenerateField(this.Size);
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
