using System;

namespace BattleField
{
    public interface IGameController
    {
        void GameOver(int detonatedMines);

        int GetPlaygroundSizeFromUser();
        
        Cell GetNextPositionForPlayFromUser(Cell[,] field);
        
        void ShowPlayground(Cell[,] field);
    }
}
