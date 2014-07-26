using System;
using System.Collections.Generic;

namespace BattleField
{
    public interface IGameboard
    {
        Cell this[int x, int y]
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
        }

        void SetDetonationFactory(IDetonationPatternFactory detonationFactory);

        void Detonate(Position position);
    }
}
