namespace BattleField
{
    using System;

    public class GameEngine
    {
        private UserController userController;
        private IGameboard board;
        private IDetonator detonator;

        public GameEngine()
        {
            this.userController = new UserController();
        }

        public void Start(IDetonator detonator)
        {
            int size = this.userController.GetPlaygroundSizeFromUser();
            this.board = Gameboard.Initialize(size);
            this.detonator = detonator;
            this.detonator.Field = board.Field;
            StartInteraction();
        }

        private void StartInteraction()
        {
            int blownMines = 0;
            while (GameServices.ContainsMines(board.Field))
            {
                Console.WriteLine(GameServices.ShowResult(board.Field));
                Cell mineToBlow = this.userController.GetNextPositionForPlayFromUser(board.Field);
                detonator.Detonate(mineToBlow);
                blownMines++;
            }

            Console.WriteLine(GameServices.ShowResult(board.Field));
            Console.WriteLine("Game over. Detonated mines: {0}", blownMines);
        }

    }
}