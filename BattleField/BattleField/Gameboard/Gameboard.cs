using BattleField.DetonationPatterns;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BattleField
{
    /// <summary>
    /// Represents the Gameboard with a field.
    /// </summary>
    public class Gameboard : IGameboard
    {
        private static IGameboard gameboard = null;
        
        private Cell[,] field;
        private int minesCount;
        private int size;
        private IDetonationPatternFactory detonationFactory;

        protected Gameboard(int size)
        {
            // TODO: Maybe extract FieldGenerator dependency
            var fieldGenerator = new FieldGenerator();
            this.Size = size;
            this.Field = fieldGenerator.GenerateField(this.Size);
        }

        /// <summary>
        /// Get/Sets the Gameboard's field 
        /// </summary>
        public Cell[,] Field
        {
            get { return this.field; }
            set { this.field = value; }
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

        public void SetDetonationFactory(IDetonationPatternFactory detonationFactory)
        {
            this.detonationFactory = detonationFactory;
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

        public void Detonate(Position position)
        {
            DetonationPattern detonationPattern = this.detonationFactory.GetDetonationPattern(position, field);
            detonationPattern.Detonate(position, ref this.field);
        }
    }
}
