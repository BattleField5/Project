namespace BattleField.Contracts
{
    using System;
    
    public interface IUiRender
    {
        void WriteLine(string text);

        void Write(string text);
    }
}
