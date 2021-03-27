using Spare.Helpers;
using System;
using Xunit;

namespace Spare.Tests.Helpers
{
    public class ActionHelperTests
    {
        [Fact]
        public void Try_ThrowAggregateException_ReturnsFalseAndAggregateException()
        {
            var result = ActionHelper.Try(() => throw new AggregateException());

            Assert.False(result.IsSuccessful);
            Assert.NotNull(result.Exception);
            Assert.IsType<AggregateException>(result.Exception);
        }
    }
}
