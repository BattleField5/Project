using System;

namespace BattleField.DetonationPatterns
{
    public class RadiusThreeDetonator : DetonationPattern
    {
        public override void Detonate(Position position, IGameboard gameboard)
        {
            int x = position.X;
            int y = position.Y;
            for (int i = x - 1; i <= x + 1; i++)
            {
                for (int j = y - 1; j <= y + 1; j++)
                {
                    if (this.IsInsideField(gameboard, i, j))
                    {
                        this.ExplodeOneMine(gameboard, i, j);
                    }
                }
            }

            if (this.IsInsideField(gameboard, x - 2, y))
            {
                this.ExplodeOneMine(gameboard, x - 2, y);
            }

            if (this.IsInsideField(gameboard, x + 2, y))
            {
                this.ExplodeOneMine(gameboard, x + 2, y);
            }

            if (this.IsInsideField(gameboard, x, y - 2))
            {
                this.ExplodeOneMine(gameboard, x, y - 2);
            }

            if (this.IsInsideField(gameboard, x, y + 2))
            {
                this.ExplodeOneMine(gameboard, x, y + 2);
            }
        }
    }
}
