using System;

namespace BattleField
{
    public interface IDetonator
    {
        Cell[,] Field { get; set; }

        void Detonate(Position position);
    }
}
