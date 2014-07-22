using System;

namespace BattleField.DetonationPatterns
{
    public class RadiusFiveDetonator : DetonationPattern
    {
        public override void Detonate(Position position, IGameboard gameboard)
        {
            for (int i = position.X - 2; i <= position.X + 2; i++)
            {
                for (int j = position.Y - 2; j <= position.Y + 2; j++)
                {
                    if (this.IsInsideField(gameboard, i, j))
                    {
                        this.ExplodeOneMine(gameboard, i, j);
                    }
                }
            }
        }
    }
}
