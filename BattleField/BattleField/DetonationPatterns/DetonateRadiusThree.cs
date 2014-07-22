using System;

namespace BattleField.DetonationPatterns
{
    public class DetonateRadiusThree : DetonationPattern
    {
        public override void Detonate(Position position, ref Cell[,] field)
        {
            int x = position.X;
            int y = position.Y;

            field[x, y].Explode();
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

            if (this.IsInsideField(field, x - 2, y))
            {
                field[x - 2, y].Explode();
            }

            if (this.IsInsideField(field, x + 2, y))
            {
                field[x + 2, y].Explode();
            }

            if (this.IsInsideField(field, x, y - 2))
            {
                field[x, y - 2].Explode();
            }

            if (this.IsInsideField(field, x, y + 2))
            {
                field[x, y + 2].Explode();
            }
        }
    }
}
