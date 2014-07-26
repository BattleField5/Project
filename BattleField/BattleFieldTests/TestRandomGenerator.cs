using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BattleField;
using BattleField.Contracts;
using BattleField.Helpers;

namespace BattleFieldTests
{
    [TestClass]
    public class TestRandomGenerator
    {
        private readonly IRandomGenerator rand = RandomGenerator.Instance;

        /// <summary>
        /// Method testing the RandomGenerator.GetRandom method for correct min values
        /// </summary>
        [TestMethod]
        public void TestRandomGeneratorGetRandomValuesForMin()
        {
            int testValue;
            int counter = 0;
            for (int i = 0; i < 1000; i++)
            {
                testValue = rand.GetRandom(1, 5);
                if (testValue < 1)
                {
                    counter++;
                }
            }

            Assert.IsTrue(counter == 0, string.Format("The random method returned {0} values below the set minimum value", counter));
        }
        /// <summary>
        /// Method testing the RandomGenerator.GetRandom method for correct max values
        /// </summary>
        /// <remarks>
        /// The RandomGenerator.GetRandom method is based on the System.Random.Next() method and always returns a max value equal to the provided param for max-1; 
        /// </remarks>
        [TestMethod]
        public void TestRandomGeneratorGetRandomValuesForMax()
        {
            int testValue;
            int counter = 0;
            for (int i = 0; i < 1000; i++)
            {
                testValue = rand.GetRandom(1, 5);
                if (testValue > 5)
                {
                    counter++;
                }
            }
            Assert.IsTrue(counter == 0, string.Format("The random method returned {0} values equal or above the set maximum value", counter));
        }

        /// <summary>
        /// Method testing if the RandomGenerator always returns only one instance as it should.
        /// </summary>
        [TestMethod]
        public void TestRandomGeneratorInstance()
        {
            IRandomGenerator secondRand = RandomGenerator.Instance;
            Assert.AreEqual(rand, secondRand, "The two generated random generators should be the same object due to the implementation of Singleton pattern on RandomGenerator.cs!");
        }
    }
}
