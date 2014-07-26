using System;
using System.Collections.Generic;
using BattleField.Helpers;

namespace BattleField.Contracts
{
    public interface IGameboard
    {
        ICell this[int x, int y]
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
