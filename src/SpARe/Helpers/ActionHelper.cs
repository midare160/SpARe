using Spare.Models;
using System;

namespace Spare.Helpers
{
    public static class ActionHelper
    {
        public static ActionResult Try(Action action)
        {
            try
            {
                action();

                return new ActionResult(true);
            }
            catch (Exception ex)
            {
                return new ActionResult(false, ex);
            }
        }
    }
}
