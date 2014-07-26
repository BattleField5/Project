using System;
using BattleField.Contracts;
using BattleField.Helpers;

namespace BattleField.Controllers
{
    public class GameController : IGameController
    {
        private IInputReader inputReader;
        private IControllerMessenger messenger;
        private IPlaygroundRender playgroundRender;

        public GameController()
            : this(new ConsoleReader(), new GameControllerMessenger(), new PlaygroundRender(new ConsoleWriter()))
        {
        }

        public GameController(IInputReader reader, IControllerMessenger messenger, IPlaygroundRender playgroundRender)
        {
            this.inputReader = reader;
            this.messenger = messenger;
            this.playgroundRender = playgroundRender;
        }

        public void SetReader(IInputReader reader)
        {
            this.inputReader = reader;
        }

        public void SetWriter(IControllerMessenger messenger)
        {
            this.messenger = messenger;
        }

        public void SetPlaygourndRender(IPlaygroundRender playgroundRender)
        {
            this.playgroundRender = playgroundRender;
        }

        public void ShowPlayground(IGameboard gameboard)
        {
            this.playgroundRender.RenderPlayground(gameboard);
        }

        public void GameOver(int detonatedMines)
        {
            this.messenger.MessageForGameOver(detonatedMines);
        }

        /// <summary>
        /// Method ask user for correct Playground size untill get correct result.
        /// </summary>
        /// <returns>Integer betwweeen 2-10</returns>
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

        /// <summary>
        /// Get coordinates from user , untill find correct position for play.
        /// </summary>
        /// <param name="gameboard"></param>
        /// <returns>Valid position</returns>
        public Position GetNextPositionForPlayFromUser(IGameboard gameboard)
        {
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

                Position validPosition = this.ExtractPositionFromString(userInput);
                if (InputValidator.IsValidMove(gameboard, validPosition.X, validPosition.Y))
                {
                    return validPosition;
                }
                else
                {
                    this.messenger.MessageForInvalidMove();
                }
            }
        }

        private Position ExtractPositionFromString(string line)
        {
            string[] splited = line.Split(' ');
            int x = int.Parse(splited[0]);
            int y = int.Parse(splited[1]);

            return new Position(x, y);
        }
    }
}
