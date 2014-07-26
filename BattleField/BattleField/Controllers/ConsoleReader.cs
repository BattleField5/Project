using System;
using BattleField.Contracts;

namespace BattleField.Controllers
{
    /// <summary>
    /// Reades user input from the Console.
    /// </summary>
    public class ConsoleReader : IInputReader
    {
        /// <summary>
        /// Waits for user input from the Console.
        /// </summary>
        public string GetUserInput()
        {
            return Console.ReadLine();
        }
    }
}
