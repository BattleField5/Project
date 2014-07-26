using System;
using BattleField.DetonationPatterns;

namespace BattleField
{
    public interface IDetonationPatternFactory
    {
        DetonationPattern GetDetonationPattern(Position position, IGameboard gameboard);
    }
}
