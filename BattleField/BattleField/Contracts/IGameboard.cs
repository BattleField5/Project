namespace BattleField.Contracts
{
    using System;
    using System.Collections.Generic;
    using BattleField.Helpers;

    public interface IGameboard
    {
        int MinesCount
        {
            get;
            set;
        }

        int Size
        {
            get;
        }

        ICell this[int x, int y]
        {
            get;
            set;
        }

        void SetDetonationFactory(IDetonationPatternFactory detonationFactory);

        void Detonate(Position position);
    }
}
