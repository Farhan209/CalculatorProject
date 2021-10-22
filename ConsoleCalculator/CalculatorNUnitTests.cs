using Moq;
using NUnit.Framework;

namespace ConsoleCalculator
{
    [TestFixture]
    class CalculatorNUnitTests
    {
        private Mock<IDiagnostics> mockLog;
        private Mock<IDBSave> mockSave;

        private CalculatorApi GetCalculator()
        {
            mockLog = new Mock<IDiagnostics>();
            mockSave = new Mock <IDBSave>();
            var calculator = new CalculatorApi(mockLog.Object, mockSave.Object);
            return calculator;
        }
        
        [TestCase(5, 5, 10)]
        [TestCase(32, 9, 41)]
        [TestCase(0, 0, 0)]
        public void AddNumbersTest(int firstNum, int secondNum, int expectedValue)
        {
            CalculatorApi calculator = GetCalculator();
            int actualValue = calculator.Add(firstNum, secondNum);
            Assert.AreEqual(expectedValue, actualValue);
            mockLog.Verify(x => x.Log(It.IsAny<string>()), Times.Once);
            // mockSave.Verify(x => x.SaveEFModel(It.IsAny<string>()), Times.Once);
            mockSave.Verify(x => x.SaveSP(It.IsAny<string>()), Times.Once);
        }

        [TestCase(10, 5, 5)]
        [TestCase(47, 17, 30)]
        [TestCase(0, 1, -1)]
        public void SubtractNumbersTest(int firstNum, int secondNum, int expectedValue)
        {
            CalculatorApi calculator = GetCalculator();
            int actualValue = calculator.Subtract(firstNum, secondNum);
            Assert.AreEqual(expectedValue, actualValue);
            mockLog.Verify(x => x.Log(It.IsAny<string>()), Times.Once);
            // mockSave.Verify(x => x.SaveEFModel(It.IsAny<string>()), Times.Once);
            mockSave.Verify(x => x.SaveSP(It.IsAny<string>()), Times.Once);
        }

        [TestCase(12, 4, 48)]
        [TestCase(10, 6, 60)]
        [TestCase(0, 1, 0)]
        public void MultiplyNumbersTest(int firstNum, int secondNum, int expectedValue)
        {
            CalculatorApi calculator = GetCalculator();
            int actualValue = calculator.Multiply(firstNum, secondNum);
            Assert.AreEqual(expectedValue, actualValue);
            mockLog.Verify(x => x.Log(It.IsAny<string>()), Times.Once);
            // mockSave.Verify(x => x.SaveEFModel(It.IsAny<string>()), Times.Once);
            mockSave.Verify(x => x.SaveSP(It.IsAny<string>()), Times.Once);
        }

        [TestCase(5, 5, 1)]
        [TestCase(84, 7, 12)]
        [TestCase(12, 6, 2)]
        public void DivideNumbersTest(int firstNum, int secondNum, int expectedValue)
        {
            CalculatorApi calculator = GetCalculator();
            int actualValue = calculator.Divide(firstNum, secondNum);
            Assert.AreEqual(expectedValue, actualValue);
            mockLog.Verify(x => x.Log(It.IsAny<string>()), Times.Once);
            // mockSave.Verify(x => x.SaveEFModel(It.IsAny<string>()), Times.Once);
            mockSave.Verify(x => x.SaveSP(It.IsAny<string>()), Times.Once);
        }

        [Test]
        public void DivideZeroTest()
        {
            CalculatorApi calculator = GetCalculator();
            int expectedValue = 0;
            int actualValue = calculator.Divide(50, 0);
            Assert.AreEqual(expectedValue, actualValue);
            mockLog.Verify(x => x.Log(It.IsAny<string>()), Times.Once);
            // mockSave.Verify(x => x.SaveEFModel(It.IsAny<string>()), Times.Once);
            mockSave.Verify(x => x.SaveSP(It.IsAny<string>()), Times.Once);
        }
    }
}
