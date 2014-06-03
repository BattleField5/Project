namespace BattleField
{
    using System;

    public static class GameEngine
    {
        private static void Start()
        {
            Console.WriteLine(@"Welcome to ""BattleField"" game.");
            Console.Write("Please enter the size of the gameboard: ");
            string userInput = Console.ReadLine();
            int size = 0;

            while (!int.TryParse(userInput, out size))
            {
                Console.WriteLine("Wrong format!");
                Console.Write("Please enter the size of the game board: ");
            }

            if (size > 10 || size <= 0)
            {
                Start();
            }

            Gameboard board = Gameboard.Initialize(size);
            StartInteraction(board);
        }

        private static void StartInteraction(Gameboard board)
        {
            string readBuffer = null;
            int blownMines = 0;

            while (GameServices.ContainsMines(board.Field))
            {
                GameServices.ShowResult(board.Field);
                Console.Write("Please enter coordinates: ");
                readBuffer = Console.ReadLine();
                Cell mineToBlow = GameServices.ExtractMineFromString(readBuffer);

                while (mineToBlow == null)
                {
                    Console.Write("Please enter coordinates: ");
                    readBuffer = Console.ReadLine();
                    mineToBlow = GameServices.ExtractMineFromString(readBuffer);
                }

                if (!GameServices.IsValidMove(board.Field, mineToBlow.X, mineToBlow.Y))
                {
                    Console.WriteLine("Invalid move!");
                    continue;
                }

                GameServices.Detonate(board.Field, mineToBlow);
                blownMines++;
            }

            GameServices.ShowResult(board.Field);
            Console.WriteLine("Game over. Detonated mines: {0}", blownMines);
        }

        /// <summary>
        /// Main function of the program and starting point of the "BattleField" game.
        /// </summary>
        public static void Main()
        {
            Start();
        }
    }
}