namespace BattleField
{
    using System;

    public class Cell : IEquatable<Cell>
    {
        private int x;
        private int y;
        private char value;

        public Cell(int x, int y) : this(x, y, '\0') { }

        public Cell(int x, int y, char value)
        {
            this.X = x;
            this.Y = y;
            this.Value = value;
        }

        public int X
        {
            get { return this.x; }
            set { this.x = value; }
        }

        public int Y
        {
            get { return this.y; }
            set { this.y = value; }
        }

        public char Value
        {
            get { return this.value; }
            set { this.value = value; }
        }

        public override string ToString()
        {
            return this.Value.ToString();
        }

        public bool IsMine()
        {
            if (this.Value != Gameboard.FieldSymbol && this.Value != Gameboard.DetonatedFieldSymbol)
            {
                return true;
            }
            else
            {
                return false;
            }
            
        }

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
