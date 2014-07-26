namespace BattleField.GameEngine
{
    using System;
    using BattleField.Cells;
    using BattleField.Contracts;
    using BattleField.Controllers;
    using BattleField.Detonation;
    using BattleField.Enumerations;
    using BattleField.Gameboard;
    using BattleField.GameEngine;
    using BattleField.Helpers;

    public class GameEngine
    {
        private readonly double LOWER_BOUND_MINES = 0.15;
        private readonly double UPPER_BOUND_MINES = 0.3;

        private IGameController gameController;
        private IGameboard board;
        private int blownMines;

        public GameEngine()
            : this(new GameController(), new GameboardGenerator(RandomGenerator.Instance), new DetonationFactory())
        {
        }

        public GameEngine(IGameController gameController, IGameboardGenerator fieldGenerator, IDetonationPatternFactory detonationFactory)
        {
            this.gameController = gameController;
            int size = this.gameController.GetPlaygroundSizeFromUser();

            double minesPercentage = this.DetermineMinesPercentage();
            this.board = fieldGenerator.Generate(size, minesPercentage);
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

        private double DetermineMinesPercentage()
        {
            double minesPercentage = RandomGenerator.Instance.GetRandom(this.LOWER_BOUND_MINES, this.UPPER_BOUND_MINES);
            return minesPercentage;
        }
    }
}