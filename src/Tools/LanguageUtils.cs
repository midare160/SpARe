using System;

namespace Spare.Tools
{
    /// <summary>
    /// Provides methods to handle any <see cref="Exception"/>.
    /// </summary>
    public static class LanguageUtils
    {
        /// <summary>
        /// Runs an <see cref="Action"/> and catches the given <see cref="Exception"/> if it occurs.
        /// </summary>
        /// <typeparam name="TException">The <see cref="Exception"/> that you want to catch.</typeparam>
        /// <param name="operation">Lambda that performs an operation that might throw.</param>
        /// <returns><see langword="true"/> if the <paramref name="operation"/> succeeds, otherwise <see langword="false"/>.</returns>
        public static bool IgnoreErrors<TException>(Action operation)
        {
            if (operation == null)
            {
                throw new ArgumentNullException(nameof(operation));
            }

            CheckIfInheritsFromException<TException>();

            try
            {
                operation.Invoke();
                return true;
            }
            catch (Exception ex) when (ex.GetType() == typeof(TException))
            {
                return false;
            }
        }

        /// <summary>
        /// Runs a <see cref="Func{TResult}"/> and catches the given <see cref="Exception"/> if it occurs.
        /// </summary>
        /// <param name="operation">Parameterless lambda that returns a value of T</param>
        /// <param name="defaultValue">Default value returned if operation fails</param>
        /// <returns>The value the <paramref name="operation"/> returns or <paramref name="defaultValue"/>, depending on whether catch was triggered or not.</returns>
        public static T IgnoreErrors<T, TException>(Func<T> operation, T defaultValue = default)
        {
            if (operation == null)
            {
                throw new ArgumentNullException(nameof(operation));
            }

            CheckIfInheritsFromException<TException>();

            try
            {
                return operation.Invoke();
            }
            catch (Exception ex) when (ex.GetType() == typeof(TException))
            {
                return defaultValue;
            }
        }

        private static void CheckIfInheritsFromException<TException>()
        {
            if (!typeof(Exception).IsAssignableFrom(typeof(TException)))
            {
                throw new ArgumentException("Type must be an Exception!", nameof(TException));
            }
        }
    }
}
