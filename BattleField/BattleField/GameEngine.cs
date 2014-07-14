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

        private static bool IsValidInput(string userInput)
        {
            int size = 0;
            if (!int.TryParse(userInput, out size))
            {
                return false;
            }
            if (1 < size && size <= 10)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private void StartInteraction()
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

                detonator.Detonate(mineToBlow);
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
            gameEngine.Start(new Detonator());
        }
    }
}