using System;

namespace BattleField
{
    /// <summary>
    /// Repersents a Cell that is empty.
    /// </summary>
    public class EmptyCell: ICell
    {
        private bool exploded;

        /// <summary>
        /// Defines if a cell is mine.
        /// </summary>
        public bool IsMine
        {
            get
            {
                return false;
            }
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
        /// Explodes the current cell.
        /// </summary>
        public virtual void Explode()
        {
            this.Exploded = true;
        }
    }
}
