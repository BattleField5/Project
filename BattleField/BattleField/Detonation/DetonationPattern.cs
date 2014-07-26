using System;
using BattleField.Contracts;
using BattleField.Helpers;

namespace BattleField.Detonation
{
    public abstract class DetonationPattern
    {
        public virtual void Detonate(Position position, IGameboard gameboard)
        {
            gameboard[position.X, position.Y].Explode();
            gameboard.MinesCount--;
        }

        protected virtual void ExplodeOneMine(IGameboard gameboard, int x, int y)
        {
            if (this.ShouldDecreaseMines(gameboard, x, y))
            {
                gameboard.MinesCount--;
            }

            gameboard[x, y].Explode();
        }

        protected virtual bool IsInsideField(IGameboard gameboard, int x, int y)
        {
            bool isInsideField = (0 <= x && x < gameboard.Size) && (0 <= y && y < gameboard.Size);

            return isInsideField;
        }

        protected virtual bool ShouldDecreaseMines(IGameboard gameboard, int x, int y)
        {
            return gameboard[x, y].IsMine && !gameboard[x, y].Exploded;
        }
    }
}
