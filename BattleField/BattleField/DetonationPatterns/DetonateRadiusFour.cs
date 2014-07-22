using System;

namespace BattleField.DetonationPatterns
{
    public class DetonateRadiusFour : DetonationPattern
    {
        public override void Detonate(Position position, ref Cell[,] field)
        {
            field[position.X, position.Y].Explode();
            for (int i = position.X - 2; i <= position.X + 2; i++)
            {
                for (int j = position.Y - 2; j <= position.Y + 2; j++)
                {
                    bool ur = i == position.X - 2 && j == position.Y - 2;
                    bool ul = i == position.X - 2 && j == position.Y + 2;
                    bool dr = i == position.X + 2 && j == position.Y - 2;
                    bool dl = i == position.X + 2 && j == position.Y + 2;

                    if (ur)
                    {
                        continue;
                    }

                    if (ul)
                    {
                        continue;
                    }

                    if (dr)
                    {
                        continue;
                    }

                    if (dl)
                    {
                        continue;
                    }

                    if (this.IsInsideField(field, i, j))
                    {
                        field[i, j].Explode();
                    }
                }
            }
        }
    }
}
