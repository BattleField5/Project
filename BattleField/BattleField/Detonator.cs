using System;

namespace BattleField
{
    /// <summary>
    /// Represent a field. Can detonate mines.
    /// </summary>
    public class Detonator : IDetonator
    {
        private Cell[,] field;

        /// <summary>
        /// Get/Sets the field
        /// </summary>
        public Cell[,] Field
        {
            get
            {
                return this.field;
            }
            set
            {
                this.field = value;
            }
        }

        /// <summary>
        /// Detonates the specified mine.
        /// </summary>
        /// <param name="cell">The mine to be detonated</param>
        public void Detonate(Cell cell)
        {
            char mineType = this.field[cell.X, cell.Y].Value;

            // TODO: Make method to work without switch.
            switch (mineType)
            {
                case '1':
                    {
                        ExplodeMineTypeOne(cell);
                        break;
                    }
                case '2':
                    {
                        ExplodeMineTypeTwo(cell);
                        break;
                    }
                case '3':
                    {
                        ExplodeMineTypeThree(cell);
                        break;
                    }
                case '4':
                    {
                        ExplodeMineTypeFour(cell);
                        break;
                    }
                case '5':
                    {
                        ExplodeMineTypeFive(cell);
                        break;
                    }
                default:
                    break;
            }
        }

        private void ExplodeMineTypeOne(Cell mine)
        {
            for (int i = mine.X - 1; i <= mine.X + 1; i += 2)
            {
                for (int j = mine.Y - 1; j <= mine.Y + 1; j += 2)
                {
                    if (IsInsideField(i, j))
                    {
                        field[mine.X, mine.Y].Detonate();
                        field[i, j].Detonate();
                    }
                }
            }
        }

        private void ExplodeMineTypeTwo(Cell mine)
        {
            for (int i = mine.X - 1; i <= mine.X + 1; i++)
            {
                for (int j = mine.Y - 1; j <= mine.Y + 1; j++)
                {
                    if (IsInsideField(i, j))
                    {
                        field[i, j].Detonate();
                    }
                }
            }
        }

        private void ExplodeMineTypeThree(Cell mine)
        {
            this.ExplodeMineTypeTwo(mine);
            int x = mine.X;
            int y = mine.Y;

            if (IsInsideField(x - 2, y))
            {
                field[x - 2, y].Detonate();
            }

            if (IsInsideField(x + 2, y))
            {
                field[x + 2, y].Detonate();
            }

            if (IsInsideField(x, y - 2))
            {
                field[x, y - 2].Detonate();
            }

            if (IsInsideField(x, y + 2))
            {
                field[x, y + 2].Detonate();
            }
        }

        private void ExplodeMineTypeFour(Cell mine)
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

                    if (IsInsideField(i, j))
                    {
                        field[i, j].Detonate();
                    }
                }
            }
        }

        private void ExplodeMineTypeFive(Cell mine)
        {
            for (int i = mine.X - 2; i <= mine.X + 2; i++)
            {
                for (int j = mine.Y - 2; j <= mine.Y + 2; j++)
                {
                    if (IsInsideField(i, j))
                    {
                        field[i, j].Detonate();
                    }
                }
            }
        }

        private bool IsInsideField(int x, int y)
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
