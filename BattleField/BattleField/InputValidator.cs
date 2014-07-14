using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace BattleField
{
    public static class InputValidator
    {
        public static bool IsValidInputForPlaygroundSize(string input)
        {
            int size = 0;
            if (!int.TryParse(input, out size))
            {
                return false;
            }
            if (1 < size && size <= 10)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public static bool IsValidInputForNextPosition(string input)
        {
            if (input.Length != 3)
            {
                return false;
            }

            var regex = new Regex("[0-9][ ][0-9]");

            return regex.IsMatch(input);
        }
    }
}
