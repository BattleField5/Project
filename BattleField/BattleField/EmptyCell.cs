using System;

namespace BattleField
{
    /// <summary>
    /// Repersents a Cell that is empty.
    /// </summary>
    public class EmptyCell: Cell
    {
        /// <summary>
        /// Creates an Empty Cell.
        /// </summary>
        /// <param name="position">Position of the Cell</param>
        public EmptyCell(Position position): base(position)
        {
        }

        public EmptyCell(int x, int y)
            : base(x, y)
        {
        }
    }
}
