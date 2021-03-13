using Spare.Extensions;
using System;
using Xunit;

namespace Spare.Tests.Extensions
{
    public class ObjectExtensionsTests
    {
        [Fact]
        public void ThrowIfNull_ArgumentNull_ArgumentExceptionThrown()
        {
            object? testObject = null;

            Assert.Throws<ArgumentNullException>(() => testObject.ThrowIfNull());
        }

        [Fact]
        public void ThrowIfNull_ArgumentNotNull_DontThrow()
        {
            var testObject = new object();
            testObject.ThrowIfNull();
        }
    }
}
