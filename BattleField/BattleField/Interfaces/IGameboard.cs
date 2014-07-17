using System;

namespace BattleField
{
    public interface IGameboard
    {
        Cell[,] Field
        {
            get;
        }

        int MinesCount
        {
            get;
        }

        int Size
        {
            get;
        }
    }
}
