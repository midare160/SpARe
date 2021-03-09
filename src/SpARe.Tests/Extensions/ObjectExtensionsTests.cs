using Spare.Extensions;
using System;
using Xunit;

namespace Spare.Tests.Extensions
{
    public class ObjectExtensionsTests
    {
        [Fact]
        public void ThrowIfNull_ArgumentNull_ExceptionThrown()
        {
            object? testObject = null;

            Assert.Throws<ArgumentNullException>(() => testObject.ThrowIfNull());
        }

        [Fact]
        public void ThrowIfNull_ArgumentNotNull_Pass()
        {
            var testObject = new object();
            testObject.ThrowIfNull();
        }

        [Fact]
        public void ThrowIfNull_StringArgumentWhiteSpace_ExceptionThrown()
        {
            var testString = " ";

            Assert.Throws<ArgumentNullException>(() => testString.ThrowIfNull());
        }

        [Fact]
        public void ThrowIfNull_StringArgumentNotNull_Pass()
        {
            var testString = "TestString";

            testString.ThrowIfNull();
        }
    }
}
