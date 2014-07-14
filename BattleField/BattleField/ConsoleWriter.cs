namespace BattleField
{
    using System;
    using System.Linq;

    public class ConsoleWriter : IUIRender
    {
        public void WriteLine(string text)
        {
            Console.WriteLine(text);
        }

        public void Write(string text)
        {
            Console.Write(text);
        }
    }
}
