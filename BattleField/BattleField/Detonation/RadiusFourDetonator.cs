using System;
using BattleField.Contracts;
using BattleField.Helpers;

namespace BattleField.Detonation
{
    public class RadiusFourDetonator : DetonationPattern
    {
        public override void Detonate(Position position, IGameboard gameboard)
        {
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

                    if (this.IsInsideField(gameboard, i, j))
                    {
                        this.ExplodeOneMine(gameboard, i, j);
                    }
                }
            }
        }
    }
}
