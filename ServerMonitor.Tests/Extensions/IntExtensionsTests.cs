using NUnit.Framework;
using ServerMonitor.Extensions;

namespace ServerMonitor.Tests.Extensions
{
    [TestFixture]
    internal class IntExtensionsTests
    {
        [Test]
        public void WhenIntPassedInRange_ShouldReturnValue()
        {
            //Arrange
            int value = 10;

            //Act
            var result = value.InRange(1, 20, 0);

            //Assert
            Assert.AreEqual(value, result);
        }

        [Test]
        public void WhenIntPassedOutOfLowRange_ShouldReturnDefault()
        {
            //Arrange
            int value = 10;
            int defaultValue = 12;

            //Act
            var result = value.InRange(15, 20, defaultValue);

            //Assert
            Assert.AreEqual(defaultValue, result);
        }

        [Test]
        public void WhenIntPassedOutOfHighRange_ShouldReturnDefault()
        {
            //Arrange
            int value = 30;
            int defaultValue = 12;

            //Act
            var result = value.InRange(15, 20, defaultValue);

            //Assert
            Assert.AreEqual(defaultValue, result);
        }
    }
}
