using System;

namespace BattleField.DetonationPatterns
{
    public abstract class DetonationPattern
    {
        public virtual void Detonate(Position position, IGameboard gameboard)
        {
            gameboard.Field[position.X, position.Y].Explode();
            gameboard.MinesCount--;
        }

        protected virtual void ExplodeOneMine(IGameboard gameboard, int x, int y)
        {
            if (this.DecreaseMines(gameboard, x, y))
            {
                gameboard.MinesCount--;
            }

            gameboard.Field[x, y].Explode();
        }

        protected virtual bool IsInsideField(IGameboard gameboard, int x, int y)
        {
            bool isInsideField = (0 <= x && x < gameboard.Size) && (0 <= y && y < gameboard.Size);

            return isInsideField;
        }

        protected virtual bool DecreaseMines(IGameboard gameboard, int x, int y)
        {
            return gameboard.Field[x, y].IsMine && !gameboard.Field[x, y].Exploded;
        }
    }
}
