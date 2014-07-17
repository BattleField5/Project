using System;

namespace BattleField
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

        public void ShowPlayground(Cell[,] field)
        {
            this.playgroundRender.RenderPlayground(field);
        }

        public void GameOver(int detonatedMines)
        {
            this.messenger.MessageForGameOver(detonatedMines);
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

        public Position GetNextPositionForPlayFromUser(Cell[,] field)
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
                if (InputValidator.IsValidMove(field, validPosition.X, validPosition.Y))
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
