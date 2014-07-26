namespace BattleField.Controllers
{
    using System;
    using BattleField.Contracts;

    /// <summary>
    /// Knows the events messages of the game.
    /// Uses a IUiRender for rendering.
    /// </summary>
    public class GameControllerMessenger : IControllerMessenger
    {
        private IUiRender render;

        public GameControllerMessenger()
            : this(new ConsoleWriter())
        {
        }

        /// <summary>
        /// Creates an instance of GameControllerMessenger
        /// </summary>
        /// <param name="render">The renderer to use</param>
        public GameControllerMessenger(IUiRender render)
        {
            this.render = render;
        }

        /// <summary>
        /// Renders the GameOver message.
        /// </summary>
        public void MessageForGameOver(int detonatedMines)
        {
            this.render.WriteLine(String.Format("Game over. Detonated mines: {0}", detonatedMines));
        }

        /// <summary>
        /// Renders a message to ask for the board size.
        /// </summary>
        public void AskForGameboardSize()
        {
            this.render.Write("Please enter the size of the gameboard: ");
        }

        /// <summary>
        /// Renders a message to ask for new coordinates.
        /// </summary>
        public void AskForNewCoordinates()
        {
            this.render.Write("Please enter coordinates: ");
        }

        /// <summary>
        /// Renders a message for a invalid move.
        /// </summary>
        public void MessageForInvalidMove()
        {
            this.render.WriteLine("Invalid move!");
        }

        /// <summary>
        /// Renders a message for a wrong gameboard field size.
        /// </summary>
        public void MessageForWrongGameboardSize()
        {
            this.render.WriteLine("Wrong input! Size must be number between 2-10");
        }

        /// <summary>
        /// Renders a message for wrong given coordinates.
        /// </summary>
        public void MessageForWrongCoordinates()
        {
            this.render.WriteLine("Wrong input! Coordinates must be 2 numbers between 0-9 , separated by space");
        }
    }
}
