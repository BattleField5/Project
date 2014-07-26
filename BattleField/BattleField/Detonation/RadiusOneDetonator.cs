using System;
using BattleField.Contracts;
using BattleField.Helpers;

namespace BattleField.Detonation
{
    public class RadiusOneDetonator : DetonationPattern
    {
        public override void Detonate(Position position, IGameboard gameboard)
        {
            base.Detonate(position, gameboard);
            for (int i = position.X - 1; i <= position.X + 1; i += 2)
            {
                for (int j = position.Y - 1; j <= position.Y + 1; j += 2)
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
