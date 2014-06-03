namespace BattleField
{
    public class Cell
    {
        private int x;
        private int y;
        private char value;

        public Cell(int x, int y)
        {
            this.X = x;
            this.Y = y;
        }

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

        public char Value
        {
            get { return this.value; }
            set { this.value = value; }
        }

        public override string ToString()
        {
            return this.Value.ToString();
        }
    }
}
