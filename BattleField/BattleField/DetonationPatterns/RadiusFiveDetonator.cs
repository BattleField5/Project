using System;

namespace BattleField.DetonationPatterns
{
    public class RadiusFiveDetonator : DetonationPattern
    {
        public override void Detonate(Position position, ref Cell[,] field)
        {
            field[position.X, position.Y].Explode();
            for (int i = position.X - 2; i <= position.X + 2; i++)
            {
                for (int j = position.Y - 2; j <= position.Y + 2; j++)
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
