using System;

namespace BattleField
{
    public interface IDetonator
    {
        void Detonate(Cell cell);
        Cell[,] Field { get; set; }
    }
}
