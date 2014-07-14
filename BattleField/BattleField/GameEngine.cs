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
            StartInteraction(board);
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

        private static void StartInteraction(IGameboard board)
        {
            string readBuffer = null;
            int blownMines = 0;
            string message;
            // int count = 0;
            // IGameboard storedBoard = new Gameboard(board.Size);
            while (GameServices.ContainsMines(board.Field))
            {
                //todo : add Memento pattern for an Undo option if move is not the first one or the game is over!
                //to save state and offer option for undo
                //if (count == 1)
                //{
                //  storedBoard.Field = board.Field;

                //}
                //Console.Write("This is the stored board");
                //Console.WriteLine(GameServices.ShowResult(storedBoard.Field));
                Console.WriteLine(GameServices.ShowResult(board.Field));
                Console.Write("Please enter coordinates: ");
                readBuffer = Console.ReadLine();
                bool isValidCommand = GameServices.ValidateCommand(readBuffer, out message);

                while (!isValidCommand)
                {
                    Console.WriteLine(message);
                    Console.Write("Please enter coordinates: ");
                    readBuffer = Console.ReadLine();
                    isValidCommand = GameServices.ValidateCommand(readBuffer, out message);
                }

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