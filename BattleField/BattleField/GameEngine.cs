using System;

namespace BattleField
{
    public class GameEngine
    {
        private IGameController gameController;
        private IGameboard board;
        private IDetonator detonator;
        private int blownMines;

        public GameEngine()
            : this(new Detonator(), new GameController())
        {
        }

        public GameEngine(IDetonator detonator, IGameController gameController)
        {
            this.gameController = gameController;
            this.detonator = detonator;
            int size = this.gameController.GetPlaygroundSizeFromUser();
            this.board = Gameboard.Initialize(size);
            this.detonator.Field = this.board.Field;
            this.blownMines = 0;
        }

        public void Start()
        {
            while (this.ContainsMines(this.board.Field))
            {
                this.gameController.ShowPlayground(this.board.Field);
                Cell mineToBlow = this.gameController.GetNextPositionForPlayFromUser(this.board.Field);
                this.detonator.Detonate(mineToBlow);
                this.blownMines++;
            }

            this.gameController.ShowPlayground(this.board.Field);
            this.gameController.GameOver(this.blownMines);
        }

        private bool ContainsMines(Cell[,] field)
        {
            for (int row = 0; row < field.GetLength(0); row++)
            {
                for (int col = 0; col < field.GetLength(1); col++)
                {
                    Cell currentCell = field[row, col];
                    if (currentCell.IsMine && !currentCell.IsDetonated)
                    {
                        return true;
                    }
                }
            }

            return false;
        }
    }
}