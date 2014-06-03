namespace BattleField
{
    using System;

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
                    if (currentCell.IsMine())
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
                char symbol = field[x, y].Value;
                if (symbol != Gameboard.DetonatedFieldSymbol && symbol != Gameboard.FieldSymbol)
                {
                    return true;
                }
            }

            return false;
        }

        public static void ShowResult(Cell[,] field)
        {
            Console.Write("   ");
            int size = field.GetLength(0);
            for (int i = 0; i < size; i++)
            {
                Console.Write("{0} ", i);
            }

            Console.WriteLine();
            Console.Write("   ");
            for (int i = 0; i < size * 2; i++)
            {
                Console.Write("-");
            }

            Console.WriteLine();

            for (int i = 0; i < size; i++)
            {
                Console.Write("{0} |", i);
                for (int j = 0; j < size; j++)
                {
                    Console.Write("{0} ", field[i, j]);
                }

                Console.WriteLine();
            }
        }

        public static Cell ExtractMineFromString(string line)
        {
            if (line == null || line.Length < CommandLength || !line.Contains(" "))
            {
                Console.WriteLine("Invalid index!");
                return null;
            }

            string[] splited = line.Split(' ');

            int x = 0;
            int y = 0;

            if (!int.TryParse(splited[0], out x))
            {
                Console.WriteLine("Invalid index!");
                return null;
            }

            if (!int.TryParse(splited[1], out y))
            {
                Console.WriteLine("Invalid index!");
                return null;
            }

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
                        field[mine.X, mine.Y].Value = Gameboard.DetonatedFieldSymbol;
                        field[i, j].Value = Gameboard.DetonatedFieldSymbol;
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
                        field[i, j].Value = Gameboard.DetonatedFieldSymbol;
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
                field[x - 2, y].Value = Gameboard.DetonatedFieldSymbol;
            }

            if (IsInsideField(field, x + 2, y))
            {
                field[x + 2, y].Value = Gameboard.DetonatedFieldSymbol;
            }

            if (IsInsideField(field, x, y - 2))
            {
                field[x, y - 2].Value = Gameboard.DetonatedFieldSymbol;
            }

            if (IsInsideField(field, x, y + 2))
            {
                field[x, y + 2].Value = Gameboard.DetonatedFieldSymbol;
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
                        field[i, j].Value = Gameboard.DetonatedFieldSymbol;
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
                        field[i, j].Value = Gameboard.DetonatedFieldSymbol;
                    }
                }
            }
        }
    }
}
