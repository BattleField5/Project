namespace BattleField.GameEngine
{
    using System;

    public class Entry
    {
        /// <summary>
        /// Main function of the program and starting point of the "BattleField" game.
        /// </summary>
        public static void Main()
        {
            var gameEngine = new GameEngine();
            gameEngine.Start();
        }
    }
}
