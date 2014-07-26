using System;

namespace BattleField
{
    public interface IGameboardGenerator
    {
        IGameboard Generate(int size, double minesPercentage);
    }
}
