using System;
using BattleField.Detonation;
using BattleField.Helpers;

namespace BattleField.Contracts
{
    public interface IDetonationPatternFactory
    {
        DetonationPattern GetDetonationPattern(Position position, IGameboard gameboard);
    }
}
