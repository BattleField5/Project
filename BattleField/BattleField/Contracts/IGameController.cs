using System;
using BattleField.Helpers;

namespace BattleField.Contracts
{
    public interface IGameController
    {
        void GameOver(int detonatedMines);

        int GetPlaygroundSizeFromUser();
        
        Position GetNextPositionForPlayFromUser(IGameboard gameboard);

        void ShowPlayground(IGameboard gameboard);
    }
}
