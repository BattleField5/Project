using System;

namespace BattleField.DetonationPatterns
{
    public abstract class DetonationPattern
    {
        public abstract void Detonate(Position position, ref Cell[,] field);

        protected virtual bool IsInsideField(Cell[,] field, int x, int y)
        {
            bool isInsideField = (0 <= x && x < field.GetLength(0)) && (0 <= y && y < field.GetLength(1));

            return isInsideField;
        }
    }
}
