using Spare.Helpers;
using System;
using System.IO;
using Xunit;

namespace Spare.Tests.Extensions
{
    public class FileHelperTests
    {
        [Fact]
        public void Delete_WhiteSpaceFile_ReturnsFalse()
        {
            var deletionResult = FileHelper.Delete(" ");

            Assert.False(deletionResult.Result);
            Assert.IsType<ArgumentException>(deletionResult.Exception);
        }

        [Fact]
        public void Delete_InvalidFile_ReturnsFalse()
        {
            var deletionResult = FileHelper.Delete(@"F:\?Test");

            Assert.False(deletionResult.Result);
            Assert.IsType<DirectoryNotFoundException>(deletionResult.Exception);
        }

        [Fact]
        public void Delete_TempFile_ReturnsTrueAndFileIsDeleted()
        {
            var tempFile = Path.GetTempFileName();
            var deletionResult = FileHelper.Delete(tempFile);

            Assert.True(deletionResult.Result);
            Assert.Null(deletionResult.Exception);
            Assert.False(File.Exists(tempFile));
        }
    }
}
