namespace BattleField.Controllers
{
    using System;
    using BattleField.Contracts;

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
