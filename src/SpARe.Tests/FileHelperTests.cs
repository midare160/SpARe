using Spare.Helpers;
using System.IO;
using Xunit;

namespace Spare.Tests
{
    public class FileHelperTests
    {
        [Fact]
        public void DeleteWhiteSpaceFile()
        {
            var deletionResult = FileHelper.Delete(" ");

            Assert.False(deletionResult);
        }

        [Fact]
        public void DeleteInvalidFile()
        {
            var deletionResult = FileHelper.Delete(@"F:\?Test");

            Assert.False(deletionResult);
        }

        [Fact]
        public void DeleteTempFile()
        {
            var tempFile = Path.GetTempFileName();
            var deletionResult = FileHelper.Delete(tempFile);

            Assert.True(deletionResult && !File.Exists(tempFile));
        }
    }
}
