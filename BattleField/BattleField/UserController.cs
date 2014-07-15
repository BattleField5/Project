using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleField
{
    public class UserController
    {
        private IInputReader inputReader;
        private IUiRender uiRender;

        public UserController()
        {
            inputReader = new ConsoleReader();
            uiRender = new ConsoleWriter();
        }

        public void SetReader(IInputReader reader)
        {
            this.inputReader = reader;
        }

        public void SetWriter(IUiRender writer)
        {
            this.uiRender = writer;
        }
        public int GetPlaygroundSizeFromUser()
        {
            this.uiRender.Write("Please enter the size of the gameboard: ");
            string userInput = this.inputReader.GetUserInput();
            while (!InputValidator.IsValidInputForPlaygroundSize(userInput))
            {
                this.uiRender.WriteLine("Wrong input! Size must be number between 2-10");
                this.uiRender.Write("Please enter the size of the game board: ");
                userInput = this.inputReader.GetUserInput();
            }
            return int.Parse(userInput);
        }

        public Cell GetNextPositionForPlayFromUser(Cell[,] field)
        {
            Cell validCell = null;
            while (true)
            {
                this.uiRender.Write("Please enter coordinates: ");
                string userInput = this.inputReader.GetUserInput();
                while (!InputValidator.IsValidInputForNextPosition(userInput))
                {
                    this.uiRender.WriteLine("Wrong input! Coordinates must be 2 numbers between 0-9 , separated by space");
                    this.uiRender.Write("Please enter coordinates: ");
                    userInput = this.inputReader.GetUserInput();
                }

                validCell = this.ExtractMineFromString(userInput);
                if (InputValidator.IsValidMove(field, validCell.X, validCell.Y))
                {
                    return validCell;
                }
                else
                {
                    this.uiRender.WriteLine("Invalid move!");
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
