using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using BattleField;

namespace BattleFieldTests
{
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
            this.gameController = new GameController(inputReader.Object, messenger.Object, playgroundRender.Object);
        }

        [TestMethod]
        public void GetPlaygroundSizeFromUserTestWithFive()
        {
            inputReader.Setup(x => x.GetUserInput()).Returns("5");
            messenger.Setup(x => x.MessageForWrongGameboardSize()).Throws(new ArgumentException("Invalid Size"));
            var controllerResult = gameController.GetPlaygroundSizeFromUser();
            var expectedResult = 5;
            Assert.AreEqual(expectedResult, controllerResult);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void GetPlaygroundSizeFromUserTestForInvalidMessage()
        {
            inputReader.Setup(x => x.GetUserInput()).Returns("0");
            messenger.Setup(x => x.MessageForWrongGameboardSize()).Throws(new ArgumentException("Invalid Size"));
            var controllerResult = gameController.GetPlaygroundSizeFromUser();
        }
        [Timeout(5000)]
        [TestMethod]
        public void GetPlaygroundSizeFromUserTestAskingForNumberUntilTakeItCorrect()
        {
            int userInput = -1;
            inputReader.Setup(x => x.GetUserInput())
                .Returns(() => userInput.ToString())
                .Callback(() => userInput++);
            var controllerResult = gameController.GetPlaygroundSizeFromUser();
            var expectedResult = 2;
            Assert.AreEqual(expectedResult, controllerResult);
        }

        [TestMethod]
        public void GetNextPositionForPlayFromUserTestForCorrectPositionWithMine()
        {
            var field = GenerateTestField.GenerateFieldWithSizeTwo();
            inputReader.Setup(x => x.GetUserInput()).Returns("0 0");
            messenger.Setup(x => x.MessageForWrongCoordinates()).Throws(new ArgumentException("Invalid Coordinates"));
            messenger.Setup(x => x.MessageForInvalidMove()).Throws(new ArgumentException("Invalid Move"));
            Position returnedPosition = gameController.GetNextPositionForPlayFromUser(field);
            bool isTheSameCell = (field[0, 0].X == returnedPosition.X && field[0, 0].Y == returnedPosition.Y);
            Assert.IsTrue(isTheSameCell);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void GetNextPositionForPlayFromUserTestForCorrectPositionButInvalidMove()
        {
            try
            {
                var field = GenerateTestField.GenerateFieldWithSizeTwo();
                inputReader.Setup(x => x.GetUserInput()).Returns("1 1");
                messenger.Setup(x => x.MessageForWrongCoordinates()).Throws(new ArgumentException("Invalid Coordinates"));
                messenger.Setup(x => x.MessageForInvalidMove()).Throws(new ArgumentException("Invalid Move"));
                Position returnedPosition = gameController.GetNextPositionForPlayFromUser(field);
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
                inputReader.Setup(x => x.GetUserInput()).Returns("111");
                messenger.Setup(x => x.MessageForWrongCoordinates()).Throws(new ArgumentException("Invalid Coordinates"));
                messenger.Setup(x => x.MessageForInvalidMove()).Throws(new ArgumentException("Invalid Move"));
                Position returnedPosition = gameController.GetNextPositionForPlayFromUser(field);
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
            var arrayWithCoordinates = new String[] {"111" , "" , "1 1" , "-5 5" , "0 0" };
            var currentIndex = 0;
            var field = GenerateTestField.GenerateFieldWithSizeTwo();
            inputReader.Setup(x => x.GetUserInput())
                .Returns(() =>arrayWithCoordinates[currentIndex])
                .Callback(()=>currentIndex++);
            Position returnedPosition = gameController.GetNextPositionForPlayFromUser(field);
            bool isTheSameCell = field[0, 0].Equals(returnedPosition);
            Assert.IsTrue(isTheSameCell);
        }
    }
}
