using System;

namespace BattleField
{
    public interface IGameController
    {
        void GameOver(int detonatedMines);

        int GetPlaygroundSizeFromUser();
        
        Position GetNextPositionForPlayFromUser(IGameboard gameboard);

        void ShowPlayground(IGameboard gameboard);
    }
}
