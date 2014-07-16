using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleField
{
    /// <summary>
    /// Reades user input from the Console.
    /// </summary>
    public class ConsoleReader : IInputReader
    {
        /// <summary>
        /// Waits for user input.
        /// </summary>
        public string GetUserInput()
        {
            return Console.ReadLine();
        }
    }
}
