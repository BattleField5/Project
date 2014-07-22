﻿using System;

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
        }

        int Size
        {
            get;
        }

        void SetDetonationFactory(IDetonationPatternFactory detonationFactory);

        void Detonate(Position position);
    }
}
