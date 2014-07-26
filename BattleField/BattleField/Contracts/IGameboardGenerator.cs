namespace BattleField.Contracts
{
    using System;

    public interface IGameboardGenerator
    {
        IGameboard Generate(int size, double minesPercentage);
    }
}
