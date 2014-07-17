using System;
using System.Linq;

namespace BattleField
{    
    /// <summary>
    /// Writes on the Console.
    /// </summary>
    public class ConsoleWriter : IUiRender
    {
        /// <summary>
        /// Write a line on the Console.
        /// </summary>
        /// <param name="text">Line to write</param>
        public void WriteLine(string text)
        {
            Console.WriteLine(text);
        }

        /// <summary>
        /// Writes on the current line of the console.
        /// </summary>
        /// <param name="text">Text to write</param>
        public void Write(string text)
        {
            Console.Write(text);
        }
    }
}
