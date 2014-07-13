﻿using System;
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
            Gameboard gameBoard = new Gameboard(size);
            int numberOfMines = GetNumberOfMines(gameBoard);
            double percentage = (double)numberOfMines / (size * size);
            bool isBetween15And30Percent = (0.15 <= percentage && percentage <= 0.30);
            Assert.IsTrue(isBetween15And30Percent, String.Format("Percentage of mines is {0}. Should be between 0.15 and 0.30. Actual number of mines is {1}.", percentage, numberOfMines));
        }

        [TestMethod]
        public void TestGameboardOfDimention5HasBetween15And30PercentMines()
        {
            int size = 5;
            Gameboard gameBoard = new Gameboard(size);
            int numberOfMines = GetNumberOfMines(gameBoard);
            double percentage = (double)numberOfMines / (size * size);
            bool isBetween15And30Percent = (0.15 <= percentage && percentage <= 0.30);
            Assert.IsTrue(isBetween15And30Percent, String.Format("Percentage of mines is {0}. Should be between 0.15 and 0.30. Actual number of mines is {1}.", percentage, numberOfMines));
        }

        private int GetNumberOfMines(Gameboard gameBoard)
        {
            int count = 0;
            Cell[,] field = gameBoard.Field;
            for (int i = 0; i < field.GetLength(0); i++)
            {
                for (int j = 0; j < field.GetLength(1); j++)
                {
                    if ('1' <= field[i, j].Value && field[i, j].Value <= '5')
                    {
                        count++;
                    }
                }
            }

            return count;
        }
    }
}