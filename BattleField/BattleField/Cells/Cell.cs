using System;

namespace BattleField
{
    /// <summary>
    /// A single cell.
    /// </summary>
    public abstract class Cell
    {
        protected bool exploded;

        /// <summary>
        /// Creates a Cell.
        /// </summary>
        public Cell()
        {
        }

        /// <summary>
        /// Defines if a cell has exploded.
        /// </summary>
        public bool Exploded
        {
            get
            {
                return this.exploded;
            }

            protected set
            {
                this.exploded = value;
            }
        }
        
        /// <summary>
        /// Defines if a cell is mine.
        /// </summary>
        public abstract bool IsMine
        {
            get;
        }

        /// <summary>
        /// Explodes the current cell.
        /// </summary>
        public virtual void Explode()
        {
            this.Exploded = true;
        }
    }
}
