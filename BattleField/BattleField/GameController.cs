using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleField
{
    public class GameController
    {
        private IInputReader inputReader;
        private IControllerMessenger messenger;

        public GameController()
        {
            this.inputReader = new ConsoleReader();
            this.messenger = new GameControllerMessenger();
        }

        public void SetReader(IInputReader reader)
        {
            this.inputReader = reader;
        }

        public void SetWriter(IControllerMessenger messenger)
        {
            this.messenger = messenger;
        }
        public int GetPlaygroundSizeFromUser()
        {
            this.messenger.AskForGameboardSize();
            string userInput = this.inputReader.GetUserInput();
            while (!InputValidator.IsValidInputForPlaygroundSize(userInput))
            {
                this.messenger.MessageForWrongGameboardSize();
                this.messenger.AskForGameboardSize();
                userInput = this.inputReader.GetUserInput();
            }
            return int.Parse(userInput);
        }

        public Cell GetNextPositionForPlayFromUser(Cell[,] field)
        {
            Cell validCell = null;
            while (true)
            {
                this.messenger.AskForNewCoordinates();
                string userInput = this.inputReader.GetUserInput();
                while (!InputValidator.IsValidInputForNextPosition(userInput))
                {
                    this.messenger.MessageForWrongCoordinates();
                    this.messenger.AskForNewCoordinates();
                    userInput = this.inputReader.GetUserInput();
                }

                validCell = this.ExtractMineFromString(userInput);
                if (InputValidator.IsValidMove(field, validCell.X, validCell.Y))
                {
                    return validCell;
                }
                else
                {
                    this.messenger.MessageForInvalidMove();
                }
            }
        }

        private Cell ExtractMineFromString(string line)
        {
            string[] splited = line.Split(' ');
            int x = int.Parse(splited[0]);
            int y = int.Parse(splited[1]);

            return new Cell(x, y);
        }

    }
}
