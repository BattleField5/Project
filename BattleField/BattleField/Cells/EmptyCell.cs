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
        public EmptyCell()
        {
        }

        public override bool IsMine
        {
            get
            {
                return false;
            }
        }
    }
}
