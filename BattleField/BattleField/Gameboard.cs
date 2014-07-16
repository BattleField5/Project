namespace BattleField
{
    using System;
    using System.Linq;
    using System.Collections.Generic;

    /// <summary>
    /// Represents the Gameboard with a field.
    /// </summary>
    public class Gameboard : IGameboard
    {
        private static IGameboard gameboard = null;
        private Cell[,] field = null;
        private int minesCount = 0;
        private int size = 0;

        protected Gameboard(int size)
        {
            // TODO: Maybe extract FieldGenerator dependency
            var fieldGenerator = new FieldGenerator();
            this.Size = size;
            this.Field = fieldGenerator.GenerateField(this.Size);
        }

        /// <summary>
        /// Creates or returns the instanced Gameboard
        /// </summary>
        /// <param name="size">Field's size</param>
        public static IGameboard Initialize(int size)
        {
            if (gameboard == null)
            {
                gameboard = new Gameboard(size);
            }
            return gameboard;
        }

        /// <summary>
        /// Get/Sets the Gameboard's field 
        /// </summary>
        public Cell[,] Field
        {
            get { return this.field; }
            private set { this.field = value; }
        }

        /// <summary>
        /// Returns the number of mines in field.
        /// </summary>
        public int MinesCount
        {
            get { return this.minesCount; }
            private set { this.minesCount = value; }
        }

        /// <summary>
        /// Returns the size of the field.
        /// </summary>
        public int Size
        {
            get { return this.size; }
            private set { this.size = value; }
        }

    }
}
