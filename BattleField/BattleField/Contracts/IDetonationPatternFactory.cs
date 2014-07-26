namespace BattleField.Contracts
{
    using System;
    using BattleField.Detonation;
    using BattleField.Helpers;

    public interface IDetonationPatternFactory
    {
        DetonationPattern GetDetonationPattern(Position position, IGameboard gameboard);
    }
}
