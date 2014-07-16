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
        private static Cell[,] GenerateTestField()
        {
            var field = new Cell[2, 2];

            field[0, 0] = new Cell(0, 0, true, 1);
            field[0, 1] = new Cell(0, 1);
            field[0, 1].Detonate();
            field[1, 0] = new Cell(1, 0);
            field[1, 1] = new Cell(1, 1);

            return field;
        }
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
        [TestMethod]
        public void GetPlaygroundSizeFromUserTestAskingForNumberUntilTakeItCorrect()
        {
            int userInput = -1;
            inputReader.Setup(x => x.GetUserInput()).Returns(() =>userInput.ToString()).Callback(() => userInput++);
            var controllerResult = gameController.GetPlaygroundSizeFromUser();
            var expectedResult = 2;
            Assert.AreEqual(expectedResult, controllerResult);
        }

    }
}
