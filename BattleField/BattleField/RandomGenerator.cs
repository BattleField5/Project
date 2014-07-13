using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleField
{

    public sealed class RandomGenerator : IRandomGenerator
    {
        internal static readonly RandomGenerator randomGeneratorInstance = new RandomGenerator();
        private Random random;

        public static RandomGenerator Instance
        {
            get
            {
                return randomGeneratorInstance;
            }
        }

        private RandomGenerator()
        {
            this.random = new Random();
        }

        public int GetRandom(int min, int max)
        {
            return random.Next(min, max);
        }
    }

}
