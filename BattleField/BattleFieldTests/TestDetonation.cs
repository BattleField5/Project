namespace BattleFieldTests
{
    using System;
    using BattleField;
    using BattleField.Cells;
    using BattleField.Contracts;
    using BattleField.Detonation;
    using BattleField.Enumerations;
    using BattleField.Gameboard;
    using BattleField.Helpers;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class TestDetonation
    {
        [TestMethod]
        public void TestDetonate1WithAllMinesInsideFieldDetonates5Cells()
        {
            IGameboard board = this.GenerateGameboard(5);
            board[1, 1] = new Mine(MineRadius.MineRadiusOne);
            board.Detonate(new Position(1, 1));
            bool patternOneDetonatesFiveCells =
                    board[1, 1].Exploded &&
                    board[0, 0].Exploded &&
                    board[0, 2].Exploded &&
                    board[2, 2].Exploded &&
                    board[2, 0].Exploded;

            Assert.IsTrue(patternOneDetonatesFiveCells);
        }

        [TestMethod]
        public void TestDetonate1WithAllMinesInsideFieldDoesNotDetonateUnnecessaryCells()
        {
            int n = 5;
            IGameboard board = this.GenerateGameboard(n);
            board[1, 1] = new Mine(MineRadius.MineRadiusOne);
            board.Detonate(new Position(1, 1));
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
                            && board[i, j].Exploded)
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
        public void TestDetonate1With2MinesInsideFieldDetonates2Cells()
        {
            IGameboard board = this.GenerateGameboard(5);
            board[0, 0] = new Mine(MineRadius.MineRadiusOne);
            board.Detonate(new Position(0, 0));
            bool twoCellsAreDetonated = board[0, 0].Exploded && board[1, 1].Exploded;

            Assert.IsTrue(twoCellsAreDetonated);
        }

        [TestMethod]
        public void TestDetonate1With2MinesInsideFieldDoesNotDetonateUnnecessaryCells()
        {
            int n = 5;
            IGameboard board = this.GenerateGameboard(n);
            board[0, 0] = new Mine(MineRadius.MineRadiusOne);
            board.Detonate(new Position(0, 0));
            int i = 0;
            int j = 0;
            bool moreThanOneCellIsDetonated = false;
            for (; i < n; i++)
            {
                for (; j < n; j++)
                {
                    if (i != 0 && j != 0 && i != 1 && j != 1 && !board[i, j].Exploded)
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
        public void TestDetonate2WithAllMinesInsideFieldDetonates9Cells()
        {
            int n = 5;
            IGameboard board = this.GenerateGameboard(n);
            board[2, 2] = new Mine(MineRadius.MineRadiusTwo);
            board.Detonate(new Position(2, 2));
            bool nineCellsAreDetonated = true;
            for (int i = 1; i <= 3; i++)
            {
                for (int j = 1; j < 3; j++)
                {
                    if (!board[i, j].Exploded)
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
        public void TestDetonate2WithAllMinesInsideFieldDoesNotDetonateUnnecessaryCells()
        {
            int n = 5;
            IGameboard board = this.GenerateGameboard(n);
            board[2, 2] = new Mine(MineRadius.MineRadiusTwo);
            board.Detonate(new Position(2, 2));
            bool moreThanNineCellsAreDetonated = false;
            int i = 0;
            int j = 0;
            for (; i < n; i++)
            {
                for (; j < n; j++)
                {
                    if (!((1 <= i) && (i <= 3) && (1 <= j) && (j <= 3)))
                    {
                        if (board[i, j].Exploded)
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
        public void TestDetonate2With4MinesInsideFieldDetonates4Cells()
        {
            int n = 5;
            IGameboard board = this.GenerateGameboard(n);
            board[4, 0] = new Mine(MineRadius.MineRadiusTwo);
            board.Detonate(new Position(4, 0));
            bool fourCellsAreDetonated =
                    board[3, 0].Exploded &&
                    board[3, 1].Exploded &&
                    board[4, 0].Exploded &&
                    board[4, 1].Exploded;

            Assert.IsTrue(fourCellsAreDetonated);
        }

        [TestMethod]
        public void TestDetonate3WithAllMinesInsideFieldDetonates13Cells()
        {
            int n = 7;
            IGameboard board = this.GenerateGameboard(n);
            Position position = new Position(3, 3);
            board[3, 3] = new Mine(MineRadius.MineRadiusThree);
            board.Detonate(position);
            bool cellsAreDetonated = true;
            for (int i = 2; i <= 4; i++)
            {
                for (int j = 2; j <= 4; j++)
                {
                    if (!board[i, j].Exploded)
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
                    board[1, 3].Exploded == board[3, 5].Exploded &&
                    board[3, 5].Exploded == board[5, 3].Exploded &&
                    board[5, 3].Exploded == board[3, 1].Exploded &&
                    board[3, 1].Exploded == true;

            Assert.IsTrue(cellsAreDetonated);
        }

        [TestMethod]
        public void TestDetonate3WithAllMinesInsideFieldDoesNotDetonateUnnecessaryCells()
        {
            int n = 9;
            IGameboard board = this.GenerateGameboard(n);
            Position position = new Position(4, 4);
            board[4, 4] = new Mine(MineRadius.MineRadiusThree);
            board.Detonate(position);
            bool moreThanThirteenCellsDetonated = false;
            int i = 0;
            int j = 0;
            for (; i < n; i++)
            {
                for (; j < n; j++)
                {
                    if (!((3 <= i) && (i <= 5) && (3 <= j) && (j <= 5)) &&
                        (i != 2 && j != 4) &&
                        (i != 4 && j != 6) &&
                        (i != 6 && j != 4) &&
                        (i != 2 && j != 2))
                    {
                        if (board[i, j].Exploded)
                        {
                            moreThanThirteenCellsDetonated = true;
                            break;
                        }
                    }
                }

                if (moreThanThirteenCellsDetonated)
                {
                    break;
                }
            }

            Assert.IsFalse(moreThanThirteenCellsDetonated, String.Format("A cell was detonated at {0}, {1}", i, j));
        }

        [TestMethod]
        public void TestDetonate3With6MinesInsideFieldDetonates6Cells()
        {
            int n = 7;
            IGameboard board = this.GenerateGameboard(n);
            Position position = new Position(6, 6);
            board[6, 6] = new Mine(MineRadius.MineRadiusThree);
            board.Detonate(position);
            bool cellsAreDetonated =
                    board[4, 6].Exploded == board[5, 5].Exploded &&
                    board[5, 5].Exploded == board[5, 6].Exploded &&
                    board[5, 6].Exploded == board[6, 4].Exploded &&
                    board[6, 4].Exploded == board[6, 5].Exploded &&
                    board[6, 5].Exploded == board[6, 6].Exploded &&
                    board[6, 6].Exploded == true;

            Assert.IsTrue(cellsAreDetonated);
        }

        [TestMethod]
        public void TestDetonate4WithAllMinesInsideFieldDetonates21Cells()
        {
            int n = 7;
            IGameboard board = this.GenerateGameboard(n);
            Position position = new Position(3, 3);
            board[3, 3] = new Mine(MineRadius.MineRadiusFour);
            board.Detonate(position);
            bool cellsAreDetonated = true;
            for (int i = 2; i <= 4; i++)
            {
                for (int j = 1; j <= 5; j++)
                {
                    if (!board[i, j].Exploded)
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
                    board[1, 2].Exploded == board[1, 3].Exploded &&
                    board[1, 3].Exploded == board[1, 4].Exploded &&
                    board[1, 4].Exploded == board[5, 2].Exploded &&
                    board[5, 2].Exploded == board[5, 3].Exploded &&
                    board[5, 3].Exploded == board[5, 4].Exploded &&
                    board[5, 4].Exploded == true;

            Assert.IsTrue(cellsAreDetonated);
        }

        [TestMethod]
        public void TestDetonate4WithAllMinesInsideFieldDoesNotDetonateUnnecessaryCells()
        {
            int n = 9;
            IGameboard board = this.GenerateGameboard(n);
            Position position = new Position(4, 4);
            board[4, 4] = new Mine(MineRadius.MineRadiusFour);
            board.Detonate(position);
            bool moreThan21CellsAreDetonated = false;
            int i = 0;
            int j = 0;
            for (; i < n; i++)
            {
                for (; j < n; j++)
                {
                    if (!((2 <= i) && (i <= 6) && (2 <= j) && (j <= 6)) ||
                            (i == 2 && j == 2) ||
                            (i == 2 && j == 6) ||
                            (i == 6 && j == 6) ||
                            (i == 6 && j == 2))
                    {
                        if (board[i, j].Exploded)
                        {
                            moreThan21CellsAreDetonated = false;
                            break;
                        }
                    }
                }

                if (!moreThan21CellsAreDetonated)
                {
                    break;
                }
            }

            Assert.IsFalse(moreThan21CellsAreDetonated);
        }

        [TestMethod]
        public void TestDetonate4With8MinesInsideFieldDetonates8Cells()
        {
            int n = 7;
            IGameboard board = this.GenerateGameboard(n);
            Position position = new Position(0, 6);
            board[0, 6] = new Mine(MineRadius.MineRadiusFour);
            board.Detonate(position);
            bool cellsAreDetonated =
                    board[0, 4].Exploded == board[0, 5].Exploded &&
                    board[0, 5].Exploded == board[0, 6].Exploded &&
                    board[0, 6].Exploded == board[1, 4].Exploded &&
                    board[1, 4].Exploded == board[1, 5].Exploded &&
                    board[1, 5].Exploded == board[1, 6].Exploded &&
                    board[1, 6].Exploded == board[2, 5].Exploded &&
                    board[2, 5].Exploded == board[2, 6].Exploded &&
                    board[2, 6].Exploded == true;

            Assert.IsTrue(cellsAreDetonated);
        }

        [TestMethod]
        public void TestDetonate5WithAllMinesInsideFieldDetonates25Cells()
        {
            int n = 9;
            IGameboard board = this.GenerateGameboard(n);
            Position position = new Position(4, 4);
            board[4, 4] = new Mine(MineRadius.MineRadiusFive);
            board.Detonate(position);
            bool cellsAreDetonated = true;
            for (int i = 2; i <= 6; i++)
            {
                for (int j = 2; j <= 6; j++)
                {
                    if (!board[i, j].Exploded)
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

            Assert.IsTrue(cellsAreDetonated);
        }

        [TestMethod]
        public void TestDetonate5WithAllMinesInsideFieldDoesNotDetonateUnnecessaryCells()
        {
            int n = 9;
            IGameboard board = this.GenerateGameboard(n);
            Position position = new Position(4, 4);
            board[4, 4] = new Mine(MineRadius.MineRadiusFive);
            board.Detonate(position);
            bool cellsAreDetonated = false;
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (!((2 <= i) && (i <= 6) && (2 <= j) && (j <= 6)))
                    {
                        if (board[i, j].Exploded)
                        {
                            cellsAreDetonated = true;
                            break;
                        }
                    }
                }

                if (cellsAreDetonated)
                {
                    break;
                }
            }

            Assert.IsFalse(cellsAreDetonated);
        }

        private IGameboard GenerateGameboard(int n)
        {
            IGameboard gameboard = new Gameboard(n);
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    gameboard[i, j] = new EmptyCell();
                }
            }

            IDetonationPatternFactory detonationFactory = new DetonationFactory();
            gameboard.SetDetonationFactory(detonationFactory);
            return gameboard;
        }
    }
}
