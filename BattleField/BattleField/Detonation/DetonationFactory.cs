namespace BattleField.Detonation
{
    using System;
    using BattleField.Cells;
    using BattleField.Contracts;
    using BattleField.Enumerations;
    using BattleField.Helpers;

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
        public DetonationPattern GetDetonationPattern(Position position, IGameboard gameboard)
        {
            DetonationPattern detonationPattern = null;

            Mine mine = (Mine)gameboard[position.X, position.Y];
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
                        throw new InvalidOperationException("No detonation pattern exists!");
                    }
            }

            return detonationPattern;
        }
    }
}
