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
        /// <param name="mine">The mine to be detonated</param>
        public void Detonate(Position position)
        {
            Mine mine = (Mine) this.field[position.X, position.Y];
            mine.Detonate();
            // TODO: Make method to work without switch.
            switch (mine.Radius)
            {
                case MineRadius.MineRadiusOne:
                    {
                        this.DetonateMineTypeOne(mine);
                        break;
                    }
                case MineRadius.MineRadiusTwo:
                    {
                        this.DetonateMineTypeTwo(mine);
                        break;
                    }
                case MineRadius.MineRadiusThree:
                    {
                        this.DetonateMineTypeThree(mine);
                        break;
                    }
                case MineRadius.MineRadiusFour:
                    {
                        this.DetonateMineTypeFour(mine);
                        break;
                    }
                case MineRadius.MineRadiusFive:
                    {
                        this.DetonateMineTypeFive(mine);
                        break;
                    }
                default:
                    break;
            }
        }

        private void DetonateMineTypeOne(Mine mine)
        {
            for (int i = mine.X - 1; i <= mine.X + 1; i += 2)
            {
                for (int j = mine.Y - 1; j <= mine.Y + 1; j += 2)
                {
                    if (this.IsInsideField(i, j))
                    {
                        this.field[mine.X, mine.Y].Explode();
                        this.field[i, j].Explode();
                    }
                }
            }
        }

        private void DetonateMineTypeTwo(Mine mine)
        {
            for (int i = mine.X - 1; i <= mine.X + 1; i++)
            {
                for (int j = mine.Y - 1; j <= mine.Y + 1; j++)
                {
                    if (this.IsInsideField(i, j))
                    {
                        this.field[i, j].Explode();
                    }
                }
            }
        }

        private void DetonateMineTypeThree(Mine mine)
        {
            this.DetonateMineTypeTwo(mine);
            int x = mine.X;
            int y = mine.Y;

            if (this.IsInsideField(x - 2, y))
            {
                this.field[x - 2, y].Explode();
            }

            if (this.IsInsideField(x + 2, y))
            {
                this.field[x + 2, y].Explode();
            }

            if (this.IsInsideField(x, y - 2))
            {
                this.field[x, y - 2].Explode();
            }

            if (this.IsInsideField(x, y + 2))
            {
                this.field[x, y + 2].Explode();
            }
        }

        private void DetonateMineTypeFour(Mine mine)
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

                    if (this.IsInsideField(i, j))
                    {
                        this.field[i, j].Explode();
                    }
                }
            }
        }

        private void DetonateMineTypeFive(Mine mine)
        {
            for (int i = mine.X - 2; i <= mine.X + 2; i++)
            {
                for (int j = mine.Y - 2; j <= mine.Y + 2; j++)
                {
                    if (this.IsInsideField(i, j))
                    {
                        this.field[i, j].Explode();
                    }
                }
            }
        }

        private bool IsInsideField(int x, int y)
        {
            bool isInsideField = false;

            if (0 <= x && x < this.field.GetLength(0))
            {
                if (0 <= y && y < this.field.GetLength(1))
                {
                    isInsideField = true;
                }
            }

            return isInsideField;
        }
    }
}
