using System;

namespace BattleField
{
    public class Mine: Cell
    {
        private MineRadius radius;
        private bool isDetonated;
        
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

        public override void Explode()
        {
            base.Explode();
            this.IsDetonated = true;
        }
    }
}
