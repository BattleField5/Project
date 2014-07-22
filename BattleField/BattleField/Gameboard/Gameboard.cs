using BattleField.DetonationPatterns;
using System;

namespace BattleField
{
    /// <summary>
    /// Represents the Gameboard with a field.
    /// </summary>
    public class Gameboard : IGameboard
    {        
        private Cell[,] field;
        private int minesCount;
        private int size;
        private IDetonationPatternFactory detonationFactory;

        /// <summary>
        /// Get/Sets the Gameboard's field.
        /// </summary>
        public Cell[,] Field
        {
            get { return this.field; }
            set { this.field = value; }
        }

        /// <summary>
        /// Gets/Sets the number of mines in field.
        /// </summary>
        public int MinesCount
        {
            get { return this.minesCount; }
            set { this.minesCount = value; }
        }

        /// <summary>
        /// Gets/Sets the size of the field.
        /// </summary>
        public int Size
        {
            get { return this.size; }
            set { this.size = value; }
        }

        /// <summary>
        /// Set the detonation factory.
        /// </summary>
        public void SetDetonationFactory(IDetonationPatternFactory detonationFactory)
        {
            this.detonationFactory = detonationFactory;
        }

        /// <summary>
        /// Detonate the mine at position 'position'.
        /// </summary>
        public void Detonate(Position position)
        {
            DetonationPattern detonationPattern = this.detonationFactory.GetDetonationPattern(position, field);
            detonationPattern.Detonate(position, this);
        }
    }
}
