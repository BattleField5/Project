namespace BattleFieldTests
{
    using System;
    using BattleField;
    using BattleField.Contracts;
    using BattleField.Controllers;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Moq;

    [TestClass]
    public class TestGameControllerMessenger
    {
        private Mock<IUiRender> render;
        private IControllerMessenger messenger;

        [TestInitialize]
        public void InitializeMock()
        {
            this.render = new Mock<IUiRender>();
            this.messenger = new GameControllerMessenger(this.render.Object);
        }

        [TestMethod]
        public void MessageForGameOverTest()
        {
            int detonatedMines = 5;
            this.messenger.MessageForGameOver(detonatedMines);
            this.CheckForExpectedMessageWithWriteLine(String.Format("Game over. Detonated mines: {0}", detonatedMines));
        }

        [TestMethod]
        public void MessageForInvalidMoveTest()
        {
            this.messenger.MessageForInvalidMove();
            this.CheckForExpectedMessageWithWriteLine("Invalid move!");
        }

        [TestMethod]
        public void MessageForWrongCoordinatesTest()
        {
            this.messenger.MessageForWrongCoordinates();
            this.CheckForExpectedMessageWithWriteLine("Wrong input! Coordinates must be 2 numbers between 0-9 , separated by space");
        }
        
        [TestMethod]
        public void MessageForWrongGameboardSizeTest()
        {
            this.messenger.MessageForWrongGameboardSize();
            this.CheckForExpectedMessageWithWriteLine("Wrong input! Size must be number between 2-10");
        }
        
        [TestMethod]
        public void AskForGameboardSizeTest()
        {
            this.messenger.AskForGameboardSize();
            this.CheckForExpectedMessageWithWrite("Please enter the size of the gameboard: ");
        }

        [TestMethod]
        public void AskForNewCoordinatesTest()
        {
            this.messenger.AskForNewCoordinates();
            this.CheckForExpectedMessageWithWrite("Please enter coordinates: ");
        }

        private void CheckForExpectedMessageWithWriteLine(string message)
        {
            this.render.Verify(w => w.WriteLine(It.Is<string>(s => s == message)), Times.Once);
        }

        private void CheckForExpectedMessageWithWrite(string message)
        {
            this.render.Verify(w => w.Write(It.Is<string>(s => s == message)), Times.Once);
        }
    }
}
