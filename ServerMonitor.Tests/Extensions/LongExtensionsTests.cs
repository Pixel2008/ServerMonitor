using NUnit.Framework;
using ServerMonitor.Extensions;
using System;

namespace ServerMonitor.Tests.Extensions
{
    [TestFixture]
    internal class LongExtensionsTests
    {
        [Test]
        [TestCase(-1, "-1B")]
        [TestCase(0, "0B")]
        [TestCase(1, "1B")]
        [TestCase(10, "10B")]
        [TestCase(100, "100B")]
        [TestCase(1000, "1000B")]
        [TestCase(10000, "9,8KB")]
        [TestCase(100000, "97,7KB")]
        [TestCase(1000000, "976,6KB")]
        [TestCase(10000000, "9,5MB")]
        [TestCase(100000000, "95,4MB")]
        [TestCase(1000000000, "953,7MB")]
        [TestCase(10000000000, "9,3GB")]
        [TestCase(100000000000, "93,1GB")]
        [TestCase(1000000000000, "931,3GB")]
        [TestCase(10000000000000, "9,1TB")]
        [TestCase(100000000000000, "90,9TB")]
        [TestCase(1000000000000000, "909,5TB")]
        [TestCase(10000000000000000, "8,9PB")]
        [TestCase(100000000000000000, "88,8PB")]
        [TestCase(1000000000000000000, "888,2PB")]
        [TestCase(Int64.MaxValue, "8EB")]
        public void WhenBytesToStringProvided_ShouldReturnProperDescription(long bytes, string expected)
        {
            //Act
            var result = bytes.BytesToString();

            //Assert
            Assert.AreEqual(expected, result);
        }
    }
}
