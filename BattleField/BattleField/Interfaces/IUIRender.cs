using System;

namespace BattleField
{
    public interface IUiRender
    {
        void WriteLine(string text);

        void Write(string text);

        void RenderField(Cell[,] field);
    }
}
