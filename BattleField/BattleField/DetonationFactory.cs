using System;
using BattleField.DetonationPatterns;

namespace BattleField
{
    /// <summary>
    /// A Factory method class that creates a detonator depending on the mine radius.
    /// </summary>
    public class DetonationFactory : IDetonationPatternFactory
    {
        /// <summary>
        /// A Factory method. Returns a detonator depending on the mine radius.
        /// </summary>
        /// <param name="position">The position to be detonated</param>
        /// <param name="field">The field to which the position belongs</param>
        public DetonationPattern GetDetonationPattern(Position position, Cell[,] field)
        {
            DetonationPattern detonationPattern = null;

            Mine mine = (Mine) field[position.X, position.Y];
            switch (mine.Radius)
            {
                case MineRadius.MineRadiusOne:
                    {
                        detonationPattern = new RadiusOneDetonator();
                        break;
                    }
                case MineRadius.MineRadiusTwo:
                    {
                        detonationPattern = new RadiusTwoDetonator();
                        break;
                    }
                case MineRadius.MineRadiusThree:
                    {
                        detonationPattern = new RadiusThreeDetonator();
                        break;
                    }
                case MineRadius.MineRadiusFour:
                    {
                        detonationPattern = new RadiusFourDetonator();
                        break;
                    }
                case MineRadius.MineRadiusFive:
                    {
                        detonationPattern = new RadiusFiveDetonator();
                        break;
                    }
                default:
                    {
                        //TODO: Custom exception
                        throw new InvalidOperationException("No detonation pattern exists!");
                    }
            }

            return detonationPattern;
        }
    }
}
