using Spare.Extensions;
using Xunit;

namespace Spare.Tests
{
    public class StringExtensionsTests
    {
        [Fact]
        public void PadCenter_StringLengthPlus10_PaddingFiveOnBothSides()
        {
            var testString = "Test";
            var expectedResult = "     Test     ";
            var actualResult = testString.PadCenter(10 + testString.Length);

            Assert.Equal(expectedResult, actualResult);
        }
    }
}
