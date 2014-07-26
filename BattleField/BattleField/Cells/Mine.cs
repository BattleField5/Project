using System;
using BattleField.Contracts;
using BattleField.Enumerations;

namespace BattleField.Cells
{
    /// <summary>
    /// Represents a Cell that is a Mine.
    /// </summary>
    public class Mine: ICell
    {
        private MineRadius radius;
        private bool exploded;

        /// <summary>
        /// Creates a Mine with mine radius.
        /// </summary>
        /// <param name="radius">Mine explode radius</param>
        public Mine(MineRadius radius)
        {
            this.radius = radius;
        }

        /// <summary>
        /// Get/Sets the Mine's explode radius.
        /// </summary>
        public MineRadius Radius
        {
            get
            {
                return this.radius;
            }

            private set
            {
                this.radius = value;
            }
        }

        /// <summary>
        /// Defines if a cell is mine.
        /// </summary>
        public bool IsMine
        {
            get
            {
                return true;
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
