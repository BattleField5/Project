using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleField
{
    public class ConsoleReader : IInputReader
    {
        public string GetUserInput()
        {
            return Console.ReadLine();
        }
    }
}
