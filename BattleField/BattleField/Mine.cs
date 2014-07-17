using System;

namespace BattleField
{
    /// <summary>
    /// Represents a Cell that is a Mine.
    /// </summary>
    public class Mine: Cell
    {
        private MineRadius radius;
        private bool isDetonated;

        /// <summary>
        /// Creates a Mine with position.
        /// </summary>
        /// <param name="position">Position of the Mine</param>
        /// <param name="radius">Mine explode radius</param>
        public Mine(Position position, MineRadius radius)
            : base(position)
        {
            this.radius = radius;
        }

        /// <summary>
        /// Creates a Cell.
        /// </summary>
        /// <param name="x">X position</param>
        /// <param name="y">Y position</param>
        /// <param name="mineCount">Mine radius</param>
        public Mine(int x, int y, MineRadius radius): base(x, y)
        {
            this.Radius = radius;
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
        /// Returns if cell is detonated
        /// </summary>
        public bool IsDetonated
        {
            get
            {
                return this.isDetonated;
            }

            private set
            {
                this.isDetonated = value;
            }
        }
        
        /// <summary>
        /// Changes the cell's Symbol. Turns IsDetonated to true.
        /// </summary>
        public void Detonate()
        {
            this.IsDetonated = true;
            this.Exploded = true;
        }

        /// <summary>
        /// Detonates the Mine.
        /// </summary>
        public override void Explode()
        {
            base.Explode();
            this.IsDetonated = true;
        }
    }
}
