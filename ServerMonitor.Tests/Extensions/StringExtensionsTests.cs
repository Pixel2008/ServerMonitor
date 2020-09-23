using NUnit.Framework;
using ServerMonitor.Extensions;

namespace ServerMonitor.Tests.Extensions
{
    [TestFixture]
    internal class StringExtensionsTests
    {
        [Test]
        public void WhenStringProvided_ShouldReturnStringWithNewLineOnEndOfIt()
        {
            //Arrange
            var input = "this is a test";
            var expected = "this is a test\r\n";

            //Act
            var result = input.NL();

            //Assert
            Assert.AreEqual(expected, result);
        }
    }
}
