using System;

namespace BattleField
{
    /// <summary>
    /// Represents a Cell that is a Mine.
    /// </summary>
    public class Mine: Cell
    {
        private MineRadius radius;

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

        public override bool IsMine
        {
            get
            {
                return true;
            }
        }
    }
}
