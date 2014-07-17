using System;
using System.Text.RegularExpressions;

namespace BattleField
{
    /// <summary>
    /// Used for validating player input.
    /// </summary>
    internal static class InputValidator
    {
        /// <summary>
        /// Returns true if input for the field size is valid
        /// </summary>
        /// <param name="input">Input for size string</param>
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
        
        /// <summary>
        /// Returns true if input for position is valid.
        /// </summary>
        /// <param name="input">Input for position string</param>
        internal static bool IsValidInputForNextPosition(string input)
        {
            if (input.Length != 3)
            {
                return false;
            }

            var regex = new Regex("[0-9][ ][0-9]");

            return regex.IsMatch(input);
        }

        /// <summary>
        /// Returns true if the move is valid.
        /// </summary>
        /// <param name="field">The field to check on</param>
        /// <param name="x">The X position on the field</param>
        /// <param name="y">The Y position on the field</param>
        internal static bool IsValidMove(Cell[,] field, int x, int y)
        {
            bool isInsideField = IsInsideField(field, x, y);
            if (isInsideField)
            {
                Mine mine = field[x, y] as Mine;
                if (mine != null && !mine.IsDetonated)
                {
                    return true;
                }
            }

            return false;
        }

        /// <summary>
        /// Returns true if the given position is inside the field.
        /// </summary>
        /// <param name="field">The field to check on</param>
        /// <param name="x">The X position on the field</param>
        /// <param name="y">The Y position on the field</param>
        private static bool IsInsideField(Cell[,] field, int x, int y)
        {
            bool isInsideField = (0 <= x && x < field.GetLength(0)) && (0 <= y && y < field.GetLength(1));

            return isInsideField;
        }
    }
}
