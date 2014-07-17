using System;

namespace BattleField
{
    public interface IRandomGenerator
    {
        int GetRandom(int min, int max);
    }
}
