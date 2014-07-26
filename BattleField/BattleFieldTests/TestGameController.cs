namespace BattleFieldTests
{
    using System;
    using BattleField;
    using BattleField.Contracts;
    using BattleField.Controllers;
    using BattleField.Helpers;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Moq;

    [TestClass]
    public class TestGameController
    {
        private Mock<IInputReader> inputReader;
        private Mock<IControllerMessenger> messenger;
        private Mock<IPlaygroundRender> playgroundRender;
        private IGameController gameController;

        [TestInitialize]
        public void InitilizeController()
        {
            this.inputReader = new Mock<IInputReader>();
            this.messenger = new Mock<IControllerMessenger>();
            this.playgroundRender = new Mock<IPlaygroundRender>();
            this.gameController = new GameController(this.inputReader.Object, this.messenger.Object, this.playgroundRender.Object);
        }

        [TestMethod]
        public void GetPlaygroundSizeFromUserTestWithFive()
        {
            this.inputReader.Setup(x => x.GetUserInput()).Returns("5");
            this.messenger.Setup(x => x.MessageForWrongGameboardSize()).Throws(new ArgumentException("Invalid Size"));
            var controllerResult = this.gameController.GetPlaygroundSizeFromUser();
            var expectedResult = 5;
            Assert.AreEqual(expectedResult, controllerResult);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void GetPlaygroundSizeFromUserTestForInvalidMessage()
        {
            this.inputReader.Setup(x => x.GetUserInput()).Returns("0");
            this.messenger.Setup(x => x.MessageForWrongGameboardSize()).Throws(new ArgumentException("Invalid Size"));
            var controllerResult = this.gameController.GetPlaygroundSizeFromUser();
        }

        [Timeout(5000)]
        [TestMethod]
        public void GetPlaygroundSizeFromUserTestAskingForNumberUntilTakeItCorrect()
        {
            int userInput = -1;
            this.inputReader.Setup(x => x.GetUserInput())
                .Returns(() => userInput.ToString())
                .Callback(() => userInput++);
            var controllerResult = this.gameController.GetPlaygroundSizeFromUser();
            var expectedResult = 2;
            Assert.AreEqual(expectedResult, controllerResult);
        }

        [TestMethod]
        public void GetNextPositionForPlayFromUserTestForCorrectPositionWithMine()
        {
            var field = GenerateTestField.GenerateFieldWithSizeTwo();
            this.inputReader.Setup(x => x.GetUserInput()).Returns("0 0");
            this.messenger.Setup(x => x.MessageForWrongCoordinates()).Throws(new ArgumentException("Invalid Coordinates"));
            this.messenger.Setup(x => x.MessageForInvalidMove()).Throws(new ArgumentException("Invalid Move"));
            Position returnedPosition = this.gameController.GetNextPositionForPlayFromUser(field);
            bool isTheSameCell = 0 == returnedPosition.X && 0 == returnedPosition.Y;
            Assert.IsTrue(isTheSameCell);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void GetNextPositionForPlayFromUserTestForCorrectPositionButInvalidMove()
        {
            try
            {
                var field = GenerateTestField.GenerateFieldWithSizeTwo();
                this.inputReader.Setup(x => x.GetUserInput()).Returns("1 1");
                this.messenger.Setup(x => x.MessageForWrongCoordinates()).Throws(new ArgumentException("Invalid Coordinates"));
                this.messenger.Setup(x => x.MessageForInvalidMove()).Throws(new ArgumentException("Invalid Move"));
                Position returnedPosition = this.gameController.GetNextPositionForPlayFromUser(field);
            }
            catch (ArgumentException ex)
            {
                Assert.AreEqual("Invalid Move", ex.Message);
                throw;
            }
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void GetNextPositionForPlayFromUserTestForInvalidPosition()
        {
            try
            {
                var field = GenerateTestField.GenerateFieldWithSizeTwo();
                this.inputReader.Setup(x => x.GetUserInput()).Returns("111");
                this.messenger.Setup(x => x.MessageForWrongCoordinates()).Throws(new ArgumentException("Invalid Coordinates"));
                this.messenger.Setup(x => x.MessageForInvalidMove()).Throws(new ArgumentException("Invalid Move"));
                Position returnedPosition = this.gameController.GetNextPositionForPlayFromUser(field);
            }
            catch (ArgumentException ex)
            {
                Assert.AreEqual("Invalid Coordinates", ex.Message);
                throw;
            }
        }

        [Timeout(5000)]
        [TestMethod]
        public void GetNextPositionForPlayFromUserTestForAskUntilGetCorrectCoordinate()
        {
            var arrayWithCoordinates = new String[] { "111", String.Empty, "1 1", "-5 5", "0 0" };
            var currentIndex = 0;
            var field = GenerateTestField.GenerateFieldWithSizeTwo();
            this.inputReader.Setup(x => x.GetUserInput())
                .Returns(() => arrayWithCoordinates[currentIndex])
                .Callback(() => currentIndex++);
            Position returnedPosition = this.gameController.GetNextPositionForPlayFromUser(field);
            bool isTheSameCell = 0 == returnedPosition.X && 0 == returnedPosition.Y;
            Assert.IsTrue(isTheSameCell);
        }
    }
}
