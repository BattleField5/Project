using System;

namespace BattleField.Contracts
{
    public interface IPlaygroundRender
    {
        void RenderPlayground(IGameboard gameboard);
    }
}
