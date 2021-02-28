using Spare.Helpers;
using System.IO;
using Xunit;

namespace Spare.Tests
{
    public class FileHelperTests
    {
        [Fact]
        public void Delete_WhiteSpaceFile_False()
        {
            var deletionResult = FileHelper.Delete(" ");

            Assert.False(deletionResult);
        }

        [Fact]
        public void Delete_InvalidFile_False()
        {
            var deletionResult = FileHelper.Delete(@"F:\?Test");

            Assert.False(deletionResult);
        }

        [Fact]
        public void Delete_TempFile_TrueAndFileDeleted()
        {
            var tempFile = Path.GetTempFileName();
            var deletionResult = FileHelper.Delete(tempFile);

            Assert.True(deletionResult && !File.Exists(tempFile));
        }
    }
}
