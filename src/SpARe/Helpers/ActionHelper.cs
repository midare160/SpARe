using Spare.Entities;
using System;

namespace Spare.Helpers
{
    public static class ActionHelper
    {
        /// <summary>
        /// Tries performing the given <paramref name="action"/> without throwing an <see cref="Exception"/>.
        /// </summary>
        /// <returns>An <see cref="ActionResult"/> with <see cref="ActionResult.IsSuccessful"/> as <see langword="true"/> if the <paramref name="action"/> was performed successfully, 
        /// otherwise <see langword="false"/> and with <see cref="ActionResult.Exception"/> as the catched <see cref="Exception"/>.</returns>
        public static ActionResult Try(Action action)
        {
            try
            {
                action();

                return new ActionResult(true);
            }
            catch (Exception ex)
            {
                return new ActionResult(ex);
            }
        }
    }
}
