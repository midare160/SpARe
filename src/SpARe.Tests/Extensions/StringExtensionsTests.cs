using Spare.Extensions;
using System;
using Xunit;

namespace Spare.Tests.Extensions
{
    public class StringExtensionsTests
    {
        [Fact]
        public void PadCenter_StringLengthPlus10_ReturnsPaddingFiveOnBothSides()
        {
            var testString = "Test";
            var expectedResult = "     Test     ";
            var actualResult = testString.PadCenter(10 + testString.Length);

            Assert.Equal(expectedResult, actualResult);
        }

        [Fact]
        public void ThrowIfNullOrEmpty_Empty_ArgumentNullExceptionThrown()
        {
            var testString = "";

            Assert.Throws<ArgumentNullException>(() => testString.ThrowIfNullOrEmpty());
        }

        [Fact]
        public void ThrowIfNullOrEmpty_NotNull_DontThrow()
        {
            var testString = "TestString";

            testString.ThrowIfNullOrEmpty();
        }
    }
}
