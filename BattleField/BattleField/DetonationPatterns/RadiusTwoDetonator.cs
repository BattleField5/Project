using System;

namespace BattleField.DetonationPatterns
{
    public class RadiusTwoDetonator : DetonationPattern
    {
        public override void Detonate(Position position, ref Cell[,] field)
        {
            field[position.X, position.Y].Explode();
            for (int i = position.X - 1; i <= position.X + 1; i++)
            {
                for (int j = position.Y - 1; j <= position.Y + 1; j++)
                {
                    if (this.IsInsideField(field, i, j))
                    {
                        field[i, j].Explode();
                    }
                }
            }
        }
    }
}
