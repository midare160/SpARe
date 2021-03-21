using System;

namespace Spare.Models
{
    public class ActionResult
    {
        public ActionResult(bool isSuccessful = false)
        {
            this.IsSuccessful = isSuccessful;
        }

        public ActionResult(Exception? exception)
        {
            this.Exception = exception;
        }

        public ActionResult(bool isSuccessful, Exception? exception) : this(isSuccessful)
        {
            this.Exception = exception;
        }

        public bool IsSuccessful { get; set; }
        public Exception? Exception { get; set; }
    }
}
