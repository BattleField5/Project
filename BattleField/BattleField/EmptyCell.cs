using System;

namespace BattleField
{
    public class EmptyCell: Cell
    {
        public EmptyCell(Position position): base(position)
        {
        }

        public EmptyCell(int x, int y)
            : base(x, y)
        {
        }
    }
}
