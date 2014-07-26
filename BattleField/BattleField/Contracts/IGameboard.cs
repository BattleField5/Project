using System;

namespace BattleField
{
    public interface IGameboard
    {
        Cell[,] Field
        {
            get;
            set;
        }

        int MinesCount
        {
            get;
            set;
        }

        int Size
        {
            get;
            set;
        }

        void SetDetonationFactory(IDetonationPatternFactory detonationFactory);

        void Detonate(Position position);
    }
}
