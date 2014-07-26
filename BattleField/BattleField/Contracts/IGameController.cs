namespace BattleField.Contracts
{
    using System;
    using BattleField.Helpers;

    public interface IGameController
    {
        void GameOver(int detonatedMines);

        int GetPlaygroundSizeFromUser();
        
        Position GetNextPositionForPlayFromUser(IGameboard gameboard);

        void ShowPlayground(IGameboard gameboard);
    }
}
