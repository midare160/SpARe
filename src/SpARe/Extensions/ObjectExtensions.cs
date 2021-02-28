using System;

namespace Spare.Extensions
{
    public static class ObjectExtensions
    {
        public static void ThrowIfArgumentNull(this object? argument, string? argumentName = null)
        {
            if (argument == null || (argument is string argumentString && string.IsNullOrWhiteSpace(argumentString)))
            {
                throw new ArgumentNullException(argumentName);
            }
        }
    }
}
