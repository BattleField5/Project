using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BattleField;

namespace BattleFieldTests
{
    [TestClass]
    public class TestGameBoardGeneration
    {
        [TestMethod]
        public void TestGameboardOfDimention10HasBetween15And30PercentMines()
        {
            int size = 10;
            var fieldGenerator = new GameboardGenerator(0.15, 0.3, RandomGenerator.Instance);
            IGameboard gameboard = fieldGenerator.Generate(size);
            Cell[,] field = gameboard.Field;
            int numberOfMines = GetNumberOfMines(field);
            double percentage = (double)numberOfMines / (size * size);
            bool isBetween15And30Percent = (0.15 <= percentage && percentage <= 0.30);
            Assert.IsTrue(isBetween15And30Percent, String.Format("Percentage of mines is {0}. Should be between 0.15 and 0.30. Actual number of mines is {1}.", percentage, numberOfMines));
        }

        [TestMethod]
        public void TestGameboardOfDimention5HasBetween15And30PercentMines()
        {
            int size = 5;
            var fieldGenerator = new GameboardGenerator(0.15, 0.3, RandomGenerator.Instance);
            Cell[,] field = (fieldGenerator.Generate(size)).Field;
            int numberOfMines = GetNumberOfMines(field);
            double percentage = (double)numberOfMines / (size * size);
            bool isBetween15And30Percent = (0.15 <= percentage && percentage <= 0.30);
            Assert.IsTrue(isBetween15And30Percent, String.Format("Percentage of mines is {0}. Should be between 0.15 and 0.30. Actual number of mines is {1}.", percentage, numberOfMines));
        }

        private int GetNumberOfMines(Cell[,] field)
        {
            int count = 0;
            for (int i = 0; i < field.GetLength(0); i++)
            {
                for (int j = 0; j < field.GetLength(1); j++)
                {
                    if (field[i, j] is Mine)
                    {
                        count++;
                    }
                }
            }

            return count;
        }
    }
}
