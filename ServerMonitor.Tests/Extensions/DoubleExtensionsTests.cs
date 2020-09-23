using NUnit.Framework;
using ServerMonitor.Extensions;

namespace ServerMonitor.Tests.Extensions
{
    [TestFixture]
    internal class DoubleExtensionsTests
    {
        [Test]
        public void WhenDoublePassedInRange_ShouldReturnValue()
        {
            //Arrange
            double value = 10;

            //Act
            var result = value.InRange(1, 20, 0);

            //Assert
            Assert.AreEqual(value, result);
        }

        [Test]
        public void WhenDoublePassedOutOfLowRange_ShouldReturnDefault()
        {
            //Arrange
            double value = 10;
            double defaultValue = 12;

            //Act
            var result = value.InRange(15, 20, defaultValue);

            //Assert
            Assert.AreEqual(defaultValue, result);
        }

        [Test]
        public void WhenDoublePassedOutOfHighRange_ShouldReturnDefault()
        {
            //Arrange
            double value = 30;
            double defaultValue = 12;

            //Act
            var result = value.InRange(15, 20, defaultValue);

            //Assert
            Assert.AreEqual(defaultValue, result);
        }
    }
}
