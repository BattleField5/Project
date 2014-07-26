namespace BattleField.Controllers
{
    using System;
    using System.Text.RegularExpressions;
    using BattleField.Contracts;

    /// <summary>
    /// Used for validating player input.
    /// </summary>
    internal static class InputValidator
    {
        private const int FIELD_MIN_SIZE = 2;
        private const int FIELD_MAX_SIZE = 10;
        private const int COMMAND_LENGTH = 3;

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

            if (FIELD_MIN_SIZE <= size && size <= FIELD_MAX_SIZE)
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
            if (input.Length != COMMAND_LENGTH)
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
        internal static bool IsValidMove(IGameboard gameboard, int x, int y)
        {
            bool isInsideField = IsInsideField(gameboard, x, y);
            if (isInsideField)
            {
                if (gameboard[x, y].IsMine && !gameboard[x, y].Exploded)
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
        private static bool IsInsideField(IGameboard gameboard, int x, int y)
        {
            bool isInsideField = (0 <= x && x < gameboard.Size) && (0 <= y && y < gameboard.Size);

            return isInsideField;
        }
    }
}
