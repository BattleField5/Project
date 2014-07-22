using System;
using BattleField.DetonationPatterns;

namespace BattleField
{
    public class GameEngine
    {
        private IGameController gameController;
        private IGameboard board;
        private IDetonationPatternFactory detonationFactory;
        private int blownMines;

        public GameEngine()
            : this(new DetonationFactory(), new GameController())
        {
        }

        public GameEngine(IDetonationPatternFactory detonationFactory, IGameController gameController)
        {
            this.gameController = gameController;
            this.detonationFactory = detonationFactory;
            int size = this.gameController.GetPlaygroundSizeFromUser();
            this.board = Gameboard.Initialize(size);
            this.blownMines = 0;
        }

        public void Start()
        {
            while (this.ContainsMines(this.board.Field))
            {
                this.gameController.ShowPlayground(this.board.Field);
                Position positionToBlow = this.gameController.GetNextPositionForPlayFromUser(this.board.Field);
                Cell[,] field = this.board.Field;
                DetonationPattern detonationPattern = this.detonationFactory.GetDetonationPattern(positionToBlow, field);
                
                detonationPattern.Detonate(positionToBlow, ref field);
                this.board.Field = field;
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
                    Mine mine = field[row, col] as Mine;
                    if (mine != null && !mine.IsDetonated)
                    {
                        return true;
                    }
                }
            }

            return false;
        }
    }
}