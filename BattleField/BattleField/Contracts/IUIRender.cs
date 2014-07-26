using System;

namespace BattleField.Contracts
{
    public interface IUiRender
    {
        void WriteLine(string text);

        void Write(string text);
    }
}
