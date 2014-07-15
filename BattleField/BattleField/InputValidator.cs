using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace BattleField
{
    internal static class InputValidator
    {
        internal static bool IsValidInputForPlaygroundSize(string input)
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
        internal static bool IsValidInputForNextPosition(string input)
        {
            if (input.Length != 3)
            {
                return false;
            }

            var regex = new Regex("[0-9][ ][0-9]");

            return regex.IsMatch(input);
        }

        internal static bool IsValidMove(Cell[,] field, int x, int y)
        {
            bool isInsideField = IsInsideField(field, x, y);
            if (isInsideField)
            {
                if (field[x, y].IsMine && !field[x, y].IsDetonated)
                {
                    return true;
                }
            }

            return false;
        }

        private static bool IsInsideField(Cell[,] field, int x, int y)
        {
            bool isInsideField = false;

            if (0 <= x && x < field.GetLength(0))
            {
                if (0 <= y && y < field.GetLength(1))
                {
                    isInsideField = true;
                }
            }

            return isInsideField;
        }
    }
}
