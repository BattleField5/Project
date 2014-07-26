using System;
using BattleField.Contracts;

namespace BattleField.Helpers
{
    public sealed class RandomGenerator : IRandomGenerator
    {
        internal static readonly RandomGenerator RandomGeneratorInstance = new RandomGenerator();
        private Random random;

        private RandomGenerator()
        {
            this.random = new Random();
        }

        public static RandomGenerator Instance
        {
            get
            {
                return RandomGeneratorInstance;
            }
        }

        public int GetRandom(int min, int max)
        {
            return this.random.Next(min, max + 1);
        }

        public double GetRandom(double min, double max)
        {
            double next = this.random.NextDouble();
            return min + (max - min) * next;
        }
    }
}
