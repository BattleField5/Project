namespace BattleField
{
    using System;

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

        public bool IsMine
        {
            get { return this.isMine; }
            set
            {
                this.isMine = value;
            }
        }

        public bool IsDetonated
        {
            get { return this.isDetonated; }
            set
            {
                this.isDetonated = value;
            }
        }

        public void Detonate()
        {
            this.IsDetonated = true;
            this.Value = DetonatedFieldSymbol;
        }

        public override string ToString()
        {
            return this.Value.ToString();
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
