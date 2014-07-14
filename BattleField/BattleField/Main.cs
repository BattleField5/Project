using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleField
{
    public class GameStart
    {
        /// <summary>
        /// Main function of the program and starting point of the "BattleField" game.
        /// </summary>
        public static void Main()
        {
            var gameEngine = new GameEngine();
            gameEngine.Start(new Detonator());
        }
    }
}
