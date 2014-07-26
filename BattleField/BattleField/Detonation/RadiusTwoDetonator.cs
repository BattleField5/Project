using System;
using BattleField.Contracts;
using BattleField.Helpers;

namespace BattleField.Detonation
{
    public class RadiusTwoDetonator : DetonationPattern
    {
        public override void Detonate(Position position, IGameboard gameboard)
        {
            for (int i = position.X - 1; i <= position.X + 1; i++)
            {
                for (int j = position.Y - 1; j <= position.Y + 1; j++)
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
