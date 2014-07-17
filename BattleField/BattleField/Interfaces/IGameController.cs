using System;

namespace BattleField
{
    public interface IGameController
    {
        void GameOver(int detonatedMines);

        int GetPlaygroundSizeFromUser();
        
        Position GetNextPositionForPlayFromUser(Cell[,] field);
        
        void ShowPlayground(Cell[,] field);
    }
}
