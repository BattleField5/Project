namespace BattleField
{
    using System;
    using System.Text;

    public static class GameServices
    {
        private const int CommandLength = 3;
        public static readonly Random RandomGenerator = new Random();        

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

        public static void Detonate(Cell[,] field, Cell mine)
        {
            char mineType = field[mine.X, mine.Y].Value;

            switch (mineType)
            {
                case '1':
                {
                    ExplodeOne(field, mine);
                    break;
                }
                case '2':
                {
                    ExplodeTwo(field, mine);
                    break;
                }
                case '3':
                {
                    ExplodeThree(field, mine);
                    break;
                }
                case '4':
                {
                    ExplodeFour(field, mine);
                    break;
                }
                case '5':
                {
                    ExplodeFive(field, mine);
                    break;
                }
                default:
                break;
            }
        }

        public static bool IsValidMove(Cell[,] field, int x, int y)
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

        public static bool ValidateCommand(string input, out string message)
        {
            if (input == null)
            {
                message = "Command can not be null!";
                return false;
            }

            if (input.Length < CommandLength)
            {
                message = "Command length must be " + CommandLength + "!";
                return false;
            }

            if (!input.Contains(" "))
            {
                message = "Indexes must be separated by space!";
                return false;
            }

            string[] splited = input.Split(' ');

            int x = 0;
            int y = 0;

            if (!int.TryParse(splited[0], out x))
            {
                message = "Invalid index!";
                return false;
            }

            if (!int.TryParse(splited[1], out y))
            {
                message = "Invalid index!";
                return false;
            }

            message = "";
            return true;
        }

        public static Cell ExtractMineFromString(string line)
        {
            string[] splited = line.Split(' ');
            int x = int.Parse(splited[0]);
            int y = int.Parse(splited[1]);

            return new Cell(x, y);
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

        private static void ExplodeOne(Cell[,] field, Cell mine)
        {
            for (int i = mine.X - 1; i <= mine.X + 1; i += 2)
            {
                for (int j = mine.Y - 1; j <= mine.Y + 1; j += 2)
                {
                    if (IsInsideField(field, i, j))
                    {
                        field[mine.X, mine.Y].Detonate();
                        field[i, j].Detonate();
                    }
                }
            }
        }

        private static void ExplodeTwo(Cell[,] field, Cell mine)
        {
            for (int i = mine.X - 1; i <= mine.X + 1; i++)
            {
                for (int j = mine.Y - 1; j <= mine.Y + 1; j++)
                {
                    if (IsInsideField(field, i, j))
                    {
                        field[i, j].Detonate();
                    }
                }
            }
        }

        private static void ExplodeThree(Cell[,] field, Cell mine)
        {
            ExplodeTwo(field, mine);
            int x = mine.X;
            int y = mine.Y;

            if (IsInsideField(field, x - 2, y))
            {
                field[x - 2, y].Detonate();
            }

            if (IsInsideField(field, x + 2, y))
            {
                field[x + 2, y].Detonate();
            }

            if (IsInsideField(field, x, y - 2))
            {
                field[x, y - 2].Detonate();
            }

            if (IsInsideField(field, x, y + 2))
            {
                field[x, y + 2].Detonate();
            }
        }

        private static void ExplodeFour(Cell[,] field, Cell mine)
        {
            for (int i = mine.X - 2; i <= mine.X + 2; i++)
            {
                for (int j = mine.Y - 2; j <= mine.Y + 2; j++)
                {
                    bool ur = i == mine.X - 2 && j == mine.Y - 2;
                    bool ul = i == mine.X - 2 && j == mine.Y + 2;
                    bool dr = i == mine.X + 2 && j == mine.Y - 2;
                    bool dl = i == mine.X + 2 && j == mine.Y + 2;

                    if (ur)
                    {
                        continue;
                    }

                    if (ul)
                    {
                        continue;
                    }

                    if (dr)
                    {
                        continue;
                    }

                    if (dl)
                    {
                        continue;
                    }

                    if (IsInsideField(field, i, j))
                    {
                        field[i, j].Detonate();
                    }
                }
            }
        }

        private static void ExplodeFive(Cell[,] field, Cell mine)
        {
            for (int i = mine.X - 2; i <= mine.X + 2; i++)
            {
                for (int j = mine.Y - 2; j <= mine.Y + 2; j++)
                {
                    if (IsInsideField(field, i, j))
                    {
                        field[i, j].Detonate();
                    }
                }
            }
        }
    }
}
