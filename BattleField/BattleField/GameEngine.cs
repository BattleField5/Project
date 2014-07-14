namespace BattleField
{
    using System;

    public class GameEngine
    {
        private UserController userController;

        public GameEngine()
        {
            this.userController = new UserController();
        }
        public void Start()
        {

            int size = this.userController.GetPlaygroundSizeFromUser();
            IGameboard board = Gameboard.Initialize(size);
            this.StartInteraction(board);
        }

        private void StartInteraction(IGameboard board)
        {
            string readBuffer = null;
            int blownMines = 0;
            // int count = 0;
            // IGameboard storedBoard = new Gameboard(board.Size);
            while (GameServices.ContainsMines(board.Field))
            {
                Console.WriteLine(GameServices.ShowResult(board.Field));
                readBuffer = this.userController.GetNextPositionForPlayFromUser();


                Cell mineToBlow = GameServices.ExtractMineFromString(readBuffer);

                if (!GameServices.IsValidMove(board.Field, mineToBlow.X, mineToBlow.Y))
                {
                    Console.WriteLine("Invalid move!");
                    continue;
                }

                GameServices.Detonate(board.Field, mineToBlow);
                blownMines++;
                //count++;
                //Console.WriteLine("Moves count: {0}",count);

            }

            Console.WriteLine(GameServices.ShowResult(board.Field));
            Console.WriteLine("Game over. Detonated mines: {0}", blownMines);
        }

        /// <summary>
        /// Main function of the program and starting point of the "BattleField" game.
        /// </summary>
        public static void Main()
        {
            var gameEngine = new GameEngine();
            gameEngine.Start();
        }
    }
}