using System;

namespace BattleField.Helpers
{
    /// <summary>
    /// Represents a x, y position.
    /// </summary>
    public struct Position
    {
        private int x;
        private int y;

        /// <summary>
        /// Get's sets X position.
        /// </summary>
        public int X
        {
            get
            {
                return this.x;
            }

            set
            {
                this.x = value;
            }
        }

        /// <summary>
        /// Get's sets Y position
        /// </summary>
        public int Y
        {
            get
            {
                return this.y;
            }

            set
            {
                this.y = value;
            }
        }

        /// <summary>
        /// Creates a Position with X and Y.
        /// </summary>
        /// <param name="x">X position</param>
        /// <param name="y">Y position</param>
        public Position(int x, int y)
        {
            this.x = x;
            this.y = y;
        }
    }
}
