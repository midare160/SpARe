using Spare.Helpers;
using System;
using System.IO;
using Xunit;

namespace Spare.Tests.Extensions
{
    public class PathHelperTests
    {
        [Fact]
        public void Delete_WhiteSpaceFile_ReturnsFalse()
        {
            var deletionResult = PathHelper.DeleteFile(" ");

            Assert.False(deletionResult.IsSuccessful);
            Assert.IsType<ArgumentException>(deletionResult.Exception);
        }

        [Fact]
        public void Delete_InvalidFile_ReturnsFalse()
        {
            var deletionResult = PathHelper.DeleteFile(@"F:\?Test");

            Assert.False(deletionResult.IsSuccessful);
            Assert.IsType<DirectoryNotFoundException>(deletionResult.Exception);
        }

        [Fact]
        public void Delete_TempFile_ReturnsTrueAndFileIsDeleted()
        {
            var tempFile = Path.GetTempFileName();
            var deletionResult = PathHelper.DeleteFile(tempFile);

            Assert.True(deletionResult.IsSuccessful);
            Assert.Null(deletionResult.Exception);
            Assert.False(File.Exists(tempFile));
        }
    }
}
