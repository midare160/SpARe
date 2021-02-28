using Spare.Extensions;
using System;
using Xunit;

namespace Spare.Tests
{
    public class ObjectExtensionsTests
    {
        [Fact]
        public void ThrowIfArgumentNull_ArgumentNull_ExceptionThrown()
        {
            object? testObject = null;

            Assert.Throws<ArgumentNullException>(() => testObject.ThrowIfArgumentNull());
        }

        [Fact]
        public void ThrowIfArgumentNull_ArgumentNotNull_Pass()
        {
            var testObject = new object();
            testObject.ThrowIfArgumentNull();
        }

        [Fact]
        public void ThrowIfArgumentNull_StringArgumentWhiteSpace_ExceptionThrown()
        {
            var testString = " ";

            Assert.Throws<ArgumentNullException>(() => testString.ThrowIfArgumentNull());
        }

        [Fact]
        public void ThrowIfArgumentNull_StringArgumentNotNull_Pass()
        {
            var testString = "TestString";

            testString.ThrowIfArgumentNull();
        }
    }
}
