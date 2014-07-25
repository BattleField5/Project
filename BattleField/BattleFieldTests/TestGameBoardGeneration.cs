using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BattleField;

namespace BattleFieldTests
{
    [TestClass]
    public class TestGameBoardGeneration
    {
        [TestMethod]
        public void TestGameboardOfDimention10AndPercentageOfMines15Has15Mines()
        {
            int size = 10;
            var fieldGenerator = new GameboardGenerator(RandomGenerator.Instance);
            IGameboard gameboard = fieldGenerator.Generate(size, 0.15);
            Cell[,] field = gameboard.Field;
            int numberOfMines = GetNumberOfMines(field);
            bool numberOfMinesIs15 = (numberOfMines == 15);
            Assert.IsTrue(numberOfMinesIs15, String.Format("Number of mines is {0}. Should be 15.", numberOfMines));
        }

        [TestMethod]
        public void TestGameboardOfDimention10AndPercentageOfMines30Has30Mines()
        {
            int size = 10;
            var fieldGenerator = new GameboardGenerator(RandomGenerator.Instance);
            IGameboard gameboard = fieldGenerator.Generate(size, 0.3);
            Cell[,] field = gameboard.Field;
            int numberOfMines = GetNumberOfMines(field);
            bool numberOfMinesIs30 = (numberOfMines == 30);
            Assert.IsTrue(numberOfMinesIs30, String.Format("Number of mines is {0}. Should be 30.", numberOfMines));
        }

        [TestMethod]
        public void TestGameboardOfDimention10AndPercentageOfMines20Has20Mines()
        {
            int size = 10;
            var fieldGenerator = new GameboardGenerator(RandomGenerator.Instance);
            IGameboard gameboard = fieldGenerator.Generate(size, 0.2);
            Cell[,] field = gameboard.Field;
            int numberOfMines = GetNumberOfMines(field);
            bool numberOfMinesIs20 = (numberOfMines == 20);
            Assert.IsTrue(numberOfMinesIs20, String.Format("Percentage of mines is {0}. Should be 20.", numberOfMines));
        }

        [TestMethod]
        public void TestGameboardOfDimention5AndPercentageOfMines20Has5Mines()
        {
            int size = 5;
            var fieldGenerator = new GameboardGenerator(RandomGenerator.Instance);
            Cell[,] field = (fieldGenerator.Generate(size, 0.2)).Field;
            int numberOfMines = GetNumberOfMines(field);
            bool numberOfMinesIs5 = (numberOfMines == 5);
            Assert.IsTrue(numberOfMinesIs5, String.Format("Number of mines is {0}. Should be 5.", numberOfMines));
        }

        private int GetNumberOfMines(Cell[,] field)
        {
            int count = 0;
            for (int i = 0; i < field.GetLength(0); i++)
            {
                for (int j = 0; j < field.GetLength(1); j++)
                {
                    if (field[i, j].IsMine)
                    {
                        count++;
                    }
                }
            }

            return count;
        }
    }
}
