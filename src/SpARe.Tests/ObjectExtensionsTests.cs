using Spare.Extensions;
using System;
using Xunit;

namespace Spare.Tests
{
    public class ObjectExtensionsTests
    {
        [Fact]
        public void ArgumentNull()
        {
            object? testObject = null;

            Assert.Throws<ArgumentNullException>(() => testObject.ThrowIfArgumentNull());
        }

        [Fact]
        public void ArgumentNotNull()
        {
            var testObject = new object();

            testObject.ThrowIfArgumentNull();
        }

        [Fact]
        public void StringArgumentWhiteSpace()
        {
            var testString = " ";

            Assert.Throws<ArgumentNullException>(() => testString.ThrowIfArgumentNull());
        }

        [Fact]
        public void StringArgumentNotNull()
        {
            var testString = "TestString";

            testString.ThrowIfArgumentNull();
        }
    }
}
