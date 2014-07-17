using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BattleField;
using Moq;
using System.Linq;

namespace BattleFieldTests
{
    [TestClass]
    public class TestPlaygroundRender
    {
        private Mock<ConsoleWriter> iURender;
        private IPlaygroundRender playgroundRender;
        [TestInitialize]
        public void InitializeRender()
        {
            this.iURender = new Mock<ConsoleWriter>();
            this.playgroundRender = new PlaygroundRender(this.iURender.Object);
        }

        [TestMethod]
        public void RenderPlaygroundTestWithPlaygroundWithSize2()
        {
            var field = GenerateTestField.GenerateFieldWithSizeTwo();
            var expectedString = "   0 1 \r\n   ----\r\n0 |1 X \r\n1 |- - \r\n";

            this.playgroundRender.RenderPlayground(field);
            this.iURender.Verify(w => w.WriteLine(It.Is<string>(fieldString => fieldString == expectedString)), Times.Once);
        }

        [TestMethod]
        public void RenderPlaygroundTestWithPlaygroundWithSize10AndEmptyCells()
        {
            var field = GenerateTestField.GenerateFieldWithSizeTenWithEmptyCells();
            var expectedString = "   0 1 2 3 4 5 6 7 8 9 \r\n" +
                                "   --------------------\r\n" +
                                "0 |- - - - - - - - - - \r\n" +
                                "1 |- - - - - - - - - - \r\n" +
                                "2 |- - - - - - - - - - \r\n" +
                                "3 |- - - - - - - - - - \r\n" +
                                "4 |- - - - - - - - - - \r\n" +
                                "5 |- - - - - - - - - - \r\n" +
                                "6 |- - - - - - - - - - \r\n" +
                                "7 |- - - - - - - - - - \r\n" +
                                "8 |- - - - - - - - - - \r\n" +
                                "9 |- - - - - - - - - - \r\n";
            this.playgroundRender.RenderPlayground(field);
            this.iURender.Verify(w => w.WriteLine(It.Is<string>(fieldString => fieldString == expectedString)), Times.Once);
        }
    }
}
