namespace BattleField.Contracts
{
    using System;
    using BattleField.Contracts;

    public interface IRandomGenerator
    {
        int GetRandom(int min, int max);

        double GetRandom(double min, double max);
    }
}
