namespace BattleField.Contracts
{
    using System;

    /// <summary>
    /// Cell interface.
    /// </summary>
    public interface ICell
    {
        /// <summary>
        /// Defines if a cell has been exploded.
        /// </summary>
        bool Exploded
        {
            get;
        }
        
        /// <summary>
        /// Defines if a cell is mine.
        /// </summary>
        bool IsMine
        {
            get;
        }

        /// <summary>
        /// Explodes the current cell.
        /// </summary>
        void Explode();
    }
}
