using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

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
