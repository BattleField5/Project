namespace BattleField
{
    using System;
    using System.Text;

    public static class GameServices
    {
        private const int CommandLength = 3;       

        public static bool ContainsMines(Cell[,] field)
        {
            for (int row = 0; row < field.GetLength(0); row++)
            {
                for (int col = 0; col < field.GetLength(1); col++)
                {
                    Cell currentCell = field[row, col];
                    if (currentCell.IsMine && !currentCell.IsDetonated)
                    {
                        return true;
                    }
                }
            }

            return false;
        }

        public static string ShowResult(Cell[,] field)
        {
            StringBuilder result = new StringBuilder();
            result.Append("   ");
            int size = field.GetLength(0);
            for (int i = 0; i < size; i++)
            {
                result.Append(i + " ");
            }

            result.AppendLine();
            result.Append("   ");
            for (int i = 0; i < size * 2; i++)
            {
                result.Append("-");
            }

            result.AppendLine();

            for (int i = 0; i < size; i++)
            {
                result.Append(i + " |");
                for (int j = 0; j < size; j++)
                {
                    result.Append(field[i, j] + " ");
                }

                result.AppendLine();
            }

            return result.ToString();
        }

    }
}
