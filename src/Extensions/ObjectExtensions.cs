using System;

namespace Spare.Extensions
{
    public static class ObjectExtensions
    {
        public static void ThrowIfNull(this object? argument, string? argumentName = null, string? message = null)
        {
            if (argument is null)
            {
                throw new ArgumentNullException(argumentName, message);
            }
        }
    }
}
