using System;

namespace BattleField.Contracts
{
    public interface IGameboardGenerator
    {
        IGameboard Generate(int size, double minesPercentage);
    }
}
