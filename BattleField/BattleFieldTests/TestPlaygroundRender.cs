using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BattleField;
using Moq;

namespace BattleFieldTests
{
    [TestClass]
    public class TestPlaygroundRender
    {
        private Mock<IUiRender> iURender;
        private IPlaygroundRender playgroundRender;
        [TestInitialize]
        public void InitializeRender()
        {
            this.iURender = new Mock<IUiRender>();
            this.playgroundRender = new PlaygroundRender(this.iURender.Object);
        }

        [TestMethod]
        public void RenderPlaygroundTestWithPlaygroundWithSize2()
        {
            var field = GenerateTestField.GenerateFieldWithSizeTwo();
            var expectedString = "   0 1 \r\n   ----\r\n0 |1 X \r\n1 |- - \r\n";
            this.playgroundRender.RenderPlayground(field);
            this.iURender.Verify(w => w.WriteLine(It.Is<string>(fieldString =>fieldString == expectedString)), Times.Once);
        }
    }
}
