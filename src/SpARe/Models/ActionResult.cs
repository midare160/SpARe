using System;

namespace Spare.Models
{
    public class ActionResult
    {
        public ActionResult(bool result = false)
        {
            this.IsSuccessful = result;
        }

        public ActionResult(bool result, Exception? exception) : this(result)
        {
            this.Exception = exception;
        }

        public bool IsSuccessful { get; set; }
        public Exception? Exception { get; set; }
    }
}
