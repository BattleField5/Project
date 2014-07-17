using System;

namespace BattleField
{
    /// <summary>
    /// A single cell.
    /// </summary>
    public abstract class Cell : IEquatable<Cell>
    {
        private Position position;
        private bool exploded;

        /// <summary>
        /// Creates a Cell with given Position object
        /// </summary>
        /// <param name="position">Position of the Cell</param>
        public Cell(Position position)
        {
            this.position = position;
        }
        
        /// <summary>
        /// Creates a Cell.
        /// </summary>
        /// <param name="x">X position</param>
        /// <param name="y">Y position</param>
        public Cell(int x, int y)
        {
            this.position = new Position(x, y);
            this.Exploded = false;
        }

        /// <summary>
        /// Returns the X position of the Cell
        /// </summary>
        public int X
        {
            get
            {
                return this.position.X;
            }
        }

        /// <summary>
        /// Returns the Y position of the Cell
        /// </summary>
        public int Y
        {
            get
            {
                return this.position.Y;
            }
        }

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

        /// <summary>
        /// Returns if coordinates are equal
        /// </summary>
        /// <param name="other">Comapring Cell</param>
        public virtual bool Equals(Cell other)
        {
            if (this.X == other.X && this.Y == other.Y)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
