namespace BattleField
{
    using System;

    public class Battlefield
    {
        private char[,] gameField;

        public Battlefield()
        {
            this.gameField = null;
        }

        public void Start()
        {
            Console.WriteLine(@"Welcome to ""Battle Field"" game. ");
            int size = 0;
            string readBuffer = null;

            Console.Write("Enter battle field size: n=");
            readBuffer = Console.ReadLine();

            while (!int.TryParse(readBuffer, out size))
            {
                Console.WriteLine("Wrong format!");
                Console.Write("Enter battle field size: n=");
            }

            if (size > 10 || size <= 0)
            {
                this.Start();
            }
            else
            {
                this.gameField = GameServices.GenerateField(size);
                this.StartInteraction();
            }
        }

        private void StartInteraction()
        {
            string readBuffer = null;
            int blownMines = 0;
            for (int i = 0; i < 50; i++)
            {
                Console.WriteLine();
            }

            while (GameServices.ContainsMines(this.gameField))
            {
                GameServices.ShowResult(this.gameField);
                Console.Write("Please enter coordinates: ");
                readBuffer = Console.ReadLine();
                Mine mineToBlow = GameServices.ExtractMineFromString(readBuffer);

                while (mineToBlow == null)
                {
                    Console.Write("Please enter coordinates: ");
                    readBuffer = Console.ReadLine();
                    mineToBlow = GameServices.ExtractMineFromString(readBuffer);
                }

                if (!GameServices.IsValidMove(this.gameField, mineToBlow.X, mineToBlow.Y))
                {
                    Console.WriteLine("Invalid move!");
                    continue;
                }

                GameServices.Detonate(this.gameField, mineToBlow);
                blownMines++;
            }

            GameServices.ShowResult(this.gameField);
            Console.WriteLine("Game over. Detonated mines: {0}", blownMines);
        }
    }
}