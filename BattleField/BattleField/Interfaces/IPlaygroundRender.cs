using System;

namespace BattleField
{
    public interface IPlaygroundRender
    {
        void RenderPlayground(Cell[,] field);
    }
}
