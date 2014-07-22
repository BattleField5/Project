using System;
using BattleField.DetonationPatterns;

namespace BattleField
{
    public class GameEngine
    {
        private IGameController gameController;
        private IGameboard board;
        private int blownMines;

        public GameEngine()
            : this(new GameController(), new GameboardGenerator(0.15, 0.3, RandomGenerator.Instance), new DetonationFactory())
        {
        }

        public GameEngine(IGameController gameController, IGameboardGenerator fieldGenerator, IDetonationPatternFactory detonationFactory)
        {
            this.gameController = gameController;
            int size = this.gameController.GetPlaygroundSizeFromUser();

            this.board = fieldGenerator.Generate(size);
            this.board.SetDetonationFactory(detonationFactory);
            
            this.blownMines = 0;
        }

        public void Start()
        {
            while (this.board.MinesCount > 0)
            {
                this.gameController.ShowPlayground(this.board);

                Position positionToBlow = this.gameController.GetNextPositionForPlayFromUser(this.board);
                this.board.Detonate(positionToBlow);
                this.blownMines++;
            }

            this.gameController.ShowPlayground(this.board);
            this.gameController.GameOver(this.blownMines);
        }
    }
}