using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BattleField;

namespace BattleFieldTests
{
    [TestClass]
    public class TestDetonation
    {
        private const char FieldSymbol = Gameboard.FieldSymbol;
        private const char DetonatedSymbol = Gameboard.DetonatedFieldSymbol;

        private Cell[,] GenerateMatrix(int n)
        {
            Cell[,] matrix = new Cell[n, n];
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    matrix[i, j] = new Cell(i, j, FieldSymbol);
                }
            }

            return matrix;
        }

        [TestMethod]
        public void TestDetonateOneWithAllMinesInsideFieldDetonatesFiveCells()
        {
            Cell[,] field = GenerateMatrix(5);
            field[1, 1].Value = '1';
            GameServices.Detonate(field, field[1, 1]);
            bool patternOneDetonatesFiveCells =
                    field[1, 1].Value == DetonatedSymbol &&
                    field[0, 0].Value == DetonatedSymbol &&
                    field[0, 2].Value == DetonatedSymbol &&
                    field[2, 2].Value == DetonatedSymbol &&
                    field[2, 0].Value == DetonatedSymbol;

            Assert.IsTrue(patternOneDetonatesFiveCells);
        }

        [TestMethod]
        public void TestDetonateOneWithAllMinesInsideFieldDoesNotDetonateUnnecessaryCells()
        {
            int n = 5;
            Cell[,] field = GenerateMatrix(n);
            field[1, 1].Value = '1';
            GameServices.Detonate(field, field[1, 1]);
            bool patternOneDetonatesMoreThanFiveCells = false;
            int i = 0;
            int j = 0;
            for (; i < n; i++)
            {
                for (; j < n; j++)
                {
                    if (
                        ((i != 1 && j != 1) && 
                            (i != 0 && j != 0) && 
                            (i != 0 && j != 2) && 
                            (i != 2 && j != 2) && 
                            (i != 2 && j != 0))
                            && field[i, j].Value == DetonatedSymbol)
                    {
                        patternOneDetonatesMoreThanFiveCells = true;
                        break;
                    }
                }

                if (patternOneDetonatesMoreThanFiveCells)
                {
                    break;
                }
            }

            Assert.IsFalse(patternOneDetonatesMoreThanFiveCells, String.Format("Mine at {0}, {1} was detonated.", i, j));
        }

        [TestMethod]
        public void TestDetonateOneWithThreeMinesOutsideFieldDetonatesTwoCells()
        {
            Cell[,] field = GenerateMatrix(5);
            field[0, 0].Value = '1';
            GameServices.Detonate(field, field[0, 0]);
            bool twoCellsAreDetonated = (field[0, 0].Value == DetonatedSymbol && field[1, 1].Value == DetonatedSymbol);

            Assert.IsTrue(twoCellsAreDetonated);
        }

        [TestMethod]
        public void TestDetonateOneWithThreeMinesOutsideFieldDoesNotDetonateUnnecessaryCells()
        {
            int n = 5;
            Cell[,] field = GenerateMatrix(n);
            field[0, 0].Value = '1';
            GameServices.Detonate(field, field[0, 0]);
            int i = 0;
            int j = 0;
            bool moreThanOneCellIsDetonated = false;
            for (; i < n; i++)
            {
                for (; j < n; j++)
                {
                    if (i != 0 && j != 0 && i != 1 && j != 1 && field[i, j].Value != DetonatedSymbol)
                    {
                        moreThanOneCellIsDetonated = true;
                        break;
                    }
                }

                if (moreThanOneCellIsDetonated)
                {
                    break;
                }
            }

            Assert.IsFalse(moreThanOneCellIsDetonated, String.Format("Cell at {0}, {1} was detonated", i, j));
        }

        [TestMethod]
        public void TestDetonateTwoWithAllMinesInsideFieldDetonatesNineCells()
        {
            int n = 5;
            Cell[,] field = GenerateMatrix(n);
            field[2, 2].Value = '2';
            GameServices.Detonate(field, field[2, 2]);
            bool nineCellsAreDetonated = true;
            for (int i = 1; i <= 3; i++)
            {
                for (int j = 1; j < 3; j++)
                {
                    if (field[i, j].Value != DetonatedSymbol)
                    {
                        nineCellsAreDetonated = false;
                        break;
                    }
                }

                if (!nineCellsAreDetonated)
                {
                    break;
                }
            }

            Assert.IsTrue(nineCellsAreDetonated);
        }

        [TestMethod]
        public void TestDetonateTwoWithAllMinesInsideFieldDoesNotDetonateMoreThanNineCells()
        {
            int n = 5;
            Cell[,] field = GenerateMatrix(n);
            field[2, 2].Value = '2';
            GameServices.Detonate(field, field[2, 2]);
            bool moreThanNineCellsAreDetonated = false;
            int i = 0;
            int j = 0;
            for (; i < n; i++)
            {
                for (; j < n; j++)
                {
                    if (! (( 1 <= i ) && (i <= 3) && (1 <= j) && (j <= 3)))
                    {
                        if (field[i, j].Value == DetonatedSymbol)
                        {
                            moreThanNineCellsAreDetonated = true;
                            break;
                        }
                    }
                }

                if (moreThanNineCellsAreDetonated)
                {
                    break;
                }
            }

            Assert.IsFalse(moreThanNineCellsAreDetonated, String.Format("Cell at {0}, {1} was detonated", i, j));
        }

        [TestMethod]
        public void TestDetonateTwoWithFourMinesInsideFieldDetonatesFourCells()
        {
            int n = 5;
            Cell[,] field = GenerateMatrix(n);
            field[4, 0].Value = '2';
            GameServices.Detonate(field, field[4, 0]);
            bool fourCellsAreDetonated = 
                    field[3, 0].Value == DetonatedSymbol &&
                    field[3, 1].Value == DetonatedSymbol &&
                    field[4, 0].Value == DetonatedSymbol &&
                    field[4, 1].Value == DetonatedSymbol;

            Assert.IsTrue(fourCellsAreDetonated);
        }

        [TestMethod]
        public void TestDetonateThreeWithThirteenMinesInsideFieldDetonatesThirteedCells()
        {
            int n = 7;
            Cell[,] field = GenerateMatrix(n);
            field[3, 3].Value = '3';
            GameServices.Detonate(field, field[3, 3]);
            bool cellsAreDetonated = true;
            for (int i = 2; i <= 4; i++)
            {
                for (int j = 2; j <= 4; j++)
                {
                    if (field[i, j].Value != DetonatedSymbol)
                    {
                        cellsAreDetonated = false;
                        break;
                    }
                }

                if (!cellsAreDetonated)
                {
                    break;
                }
            }

            cellsAreDetonated = cellsAreDetonated && 
                    field[1, 3].Value == field[3, 5].Value &&
                    field[3, 5].Value == field[5, 3].Value && 
                    field[5, 3].Value == field[3, 1].Value && 
                    field[3, 1].Value == DetonatedSymbol;

            Assert.IsTrue(cellsAreDetonated);
        }

        [TestMethod]
        public void TestDetonateThreeWithThirteenMinesInsideFieldDoesNotDetonateUnnecessaryCells()
        { }
    }
}
