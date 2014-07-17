using System;

namespace BattleField
{
    public class PlaygroundRender : IPlaygroundRender
    {
        private IUiRender renderer;

        public PlaygroundRender(IUiRender renderer)
        {
            this.renderer = renderer;
        }

        public void RenderPlayground(Cell[,] field)
        {
            this.renderer.RenderField(field);
        }
    }
}
