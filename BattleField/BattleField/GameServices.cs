using System;
using System.Collections.Generic;

namespace BattleField
{
    public class GameServices
    {
        private static readonly Random rand = new Random();
        private const double LOWER_BOUND_MINES = 0.15;
        private const double UPPER_BOUND_MINES = 0.3;
        private const char FIELD_SYMBOL = '-';
        private const char DETONATED_FIELD_SYMBOL = 'X';
        private const int COMMAND_LENGTH = 3;

        public static char[,] GenerateField(int size)
        {
            char[,] field = new char[size, size];
            int minesCount = DetermineMineCount(size);

            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    field[i, j] = FIELD_SYMBOL;
                }
            }

            List<Mine> mines = new List<Mine>();
            for (int i = 0; i < minesCount; i++)
            {
                int mineX = rand.Next(0, size);
                int mineY = rand.Next(0, size);
                Mine newMine = new Mine(mineX, mineY);

                if (GameServices.Contains(mines, newMine))
                {
                    i--;
                    continue;
                }

                int mineType = rand.Next('1', '6');
                field[mineX, mineY] = Convert.ToChar(mineType);
            }

            return field;
        }

        private static int DetermineMineCount(int size)
        {
            double fields = (double)size * size;
            int lowBound = (int)(LOWER_BOUND_MINES * fields);
            int upperBound = (int)(UPPER_BOUND_MINES * fields);

            return rand.Next(lowBound, upperBound);
        }

        private static bool Contains(List<Mine> list, Mine mine)
        {
            return list.Contains(mine);
        }

        public static bool ContainsMines(char[,] field)
        {
            for (int i = 0; i < field.GetLength(0); i++)
            {
                for (int j = 0; j < field.GetLength(1); j++)
                {
                    if (field[i, j] != FIELD_SYMBOL && field[i, j] != DETONATED_FIELD_SYMBOL)
                    {
                        return true;
                    }
                }
            }

            return false;
        }

        private static bool IsInsideField(char[,] field, int x, int y)
        {
            bool isInsideField = (0 <= x && x < field.GetLength(0) && 0 <= y && y < field.GetLength(1));
            return isInsideField;
        }

        public static void Detonate(char[,] field, Mine mine)
        {
            char mineType = field[mine.X, mine.Y];

            switch (mineType)
            {
                case '1':
                    {
                        ExplodeOne(field, mine);
                    }
                    break;
                case '2':
                    {
                        ExplodeTwo(field, mine);
                    }
                    break;
                case '3':
                    {
                        ExplodeThree(field, mine);
                    }
                    break;
                case '4':
                    {
                        ExplodeFour(field, mine);
                    }
                    break;
                case '5':
                    {
                        ExplodeFive(field, mine);
                    }
                    break;
            }
        }

        private static void ExplodeOne(char[,] field, Mine mine)
        {
            int x = mine.X;
            int y = mine.Y;

            if (IsInsideField(field, x, y))
            {
                field[x, y] = DETONATED_FIELD_SYMBOL;
            }

            if (IsInsideField(field, x - 1, y - 1))
            {
                field[x - 1, y - 1] = DETONATED_FIELD_SYMBOL;
            }

            if (IsInsideField(field, x - 1, y + 1))
            {
                field[x - 1, y + 1] = DETONATED_FIELD_SYMBOL;
            }

            if (IsInsideField(field, x + 1, y - 1))
            {
                field[x + 1, y - 1] = DETONATED_FIELD_SYMBOL;
            }

            if (IsInsideField(field, x + 1, y + 1))
            {
                field[x + 1, y + 1] = DETONATED_FIELD_SYMBOL;
            }
        }

        private static void ExplodeTwo(char[,] field, Mine mine)
        {
            for (int i = mine.X - 1; i <= mine.X + 1; i++)
            {
                for (int j = mine.Y - 1; j <= mine.Y + 1; j++)
                {
                    if (IsInsideField(field, i, j))
                    {
                        field[i, j] = DETONATED_FIELD_SYMBOL;
                    }
                }
            }
        }

        private static void ExplodeThree(char[,] field, Mine mine)
        {
            ExplodeTwo(field, mine);
            int x = mine.X;
            int y = mine.Y;

            if (IsInsideField(field, x - 2, y))
            {
                field[x - 2, y] = DETONATED_FIELD_SYMBOL;
            }

            if (IsInsideField(field, x + 2, y))
            {
                field[x + 2, y] = DETONATED_FIELD_SYMBOL;
            }

            if (IsInsideField(field, x, y - 2))
            {
                field[x, y - 2] = DETONATED_FIELD_SYMBOL;
            }

            if (IsInsideField(field, x, y + 2))
            {
                field[x, y + 2] = DETONATED_FIELD_SYMBOL;
            }
        }

        private static void ExplodeFour(char[,] field, Mine mine)
        {
            for (int i = mine.X - 2; i <= mine.X + 2; i++)
            {
                for (int j = mine.Y - 2; j <= mine.Y + 2; j++)
                {
                    bool UR = i == mine.X - 2 && j == mine.Y - 2;
                    bool UL = i == mine.X - 2 && j == mine.Y + 2;
                    bool DR = i == mine.X + 2 && j == mine.Y - 2;
                    bool DL = i == mine.X + 2 && j == mine.Y + 2;

                    if (UR) continue;
                    if (UL) continue;
                    if (DR) continue;
                    if (DL) continue;

                    if (IsInsideField(field, i, j))
                    {
                        field[i, j] = DETONATED_FIELD_SYMBOL;
                    }
                }
            }

        }

        private static void ExplodeFive(char[,] field, Mine mine)
        {
            for (int i = mine.X - 2; i <= mine.X + 2; i++)
            {
                for (int j = mine.Y - 2; j <= mine.Y + 2; j++)
                {
                    if (IsInsideField(field, i, j))
                    {
                        field[i, j] = DETONATED_FIELD_SYMBOL;
                    }
                }
            }
        }

        public static bool IsValidMove(char[,] field, int x, int y)
        {
            bool isInsideField = IsInsideField(field, x, y);
            if (isInsideField)
            {
                char symbol = field[x, y];
                if (symbol != DETONATED_FIELD_SYMBOL && symbol != FIELD_SYMBOL)
                {
                    return true;
                }
            }

            return false;
        }

        public static void ShowResult(char[,] field)
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

        public static Mine ExtractMineFromString(string line)
        {
            if (line == null || line.Length < COMMAND_LENGTH || !line.Contains(" "))
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

            return new Mine(x, y);
        }
    }
}
