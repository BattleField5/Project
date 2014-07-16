namespace BattleField
{
    using System;

    /// <summary>
    /// A single cell. Can be a mine.
    /// </summary>
    public class Cell : IEquatable<Cell>
    {
        private const char FieldSymbol = '-';
        private const char DetonatedFieldSymbol = 'X';

        private int x;
        private int y;
        private char value;
        private bool isMine;
        private bool isDetonated;

        public Cell(int x, int y) : this(x, y, false) { }

        /// <summary>
        /// Creates a Cell.
        /// </summary>
        /// <param name="x">X position</param>
        /// <param name="y">Y position</param>
        /// <param name="isMine">If should be a mine</param>
        /// <param name="mineCount">Mine radius</param>
        public Cell(int x, int y, bool isMine, int mineCount = 0)
        {
            this.X = x;
            this.Y = y;
            if (isMine)
            {
                this.IsMine = true;
                this.IsDetonated = false;
                this.Value = (char)(mineCount + 48);
            }
            else
            {
                this.IsMine = false;
                this.Value = FieldSymbol;
            }
        }
        /// <summary>
        /// Returns the X position of the Cell
        /// </summary>
        public int X
        {
            get { return this.x; }
            set { this.x = value; }
        }

        /// <summary>
        /// Returns the Y position of the Cell
        /// </summary>
        public int Y
        {
            get { return this.y; }
            set { this.y = value; }
        }
        /// <summary>
        /// Returns the symbol of the cell
        /// </summary>
        public char Value
        {
            get { return this.value; }
            set { this.value = value; }
        }

        /// <summary>
        /// Returns true if the cell is a mine
        /// </summary>
        public bool IsMine
        {
            get { return this.isMine; }
            set
            {
                this.isMine = value;
            }
        }
        /// <summary>
        /// Returns if cell is detonated
        /// </summary>
        public bool IsDetonated
        {
            get { return this.isDetonated; }
            set
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
            this.Value = DetonatedFieldSymbol;
        }

        /// <summary>
        /// Returns cell's char value
        /// </summary>
        public override string ToString()
        {
            return this.Value.ToString();
        }

        /// <summary>
        /// Returns if coordinates are equal
        /// </summary>
        /// <param name="other">Comapring Cell</param>
        public bool Equals(Cell other)
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
