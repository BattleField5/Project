using System;

namespace BattleField.DetonationPatterns
{
    public class RadiusOneDetonator : DetonationPattern
    {
        public override void Detonate(Position position, ref Cell[,] field)
        {
            field[position.X, position.Y].Explode();
            for (int i = position.X - 1; i <= position.X + 1; i += 2)
            {
                for (int j = position.Y - 1; j <= position.Y + 1; j += 2)
                {
                    if (this.IsInsideField(field, i, j))
                    {
                        field[position.X, position.Y].Explode();
                        field[i, j].Explode();
                    }
                }
            }
        }
    }
}
