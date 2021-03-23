using System;

namespace Spare.Entities
{
    public class ActionResult
    {
        public ActionResult(bool isSuccessful = false) : this(isSuccessful, null) { }

        public ActionResult(Exception? exception) : this(false, exception) { }

        public ActionResult(bool isSuccessful, Exception? exception)
        {
            this.IsSuccessful = isSuccessful;
            this.Exception = exception;
        }

        public bool IsSuccessful { get; set; }
        public Exception? Exception { get; set; }
    }
}
