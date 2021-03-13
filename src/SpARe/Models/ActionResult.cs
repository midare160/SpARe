using System;

namespace Spare.Models
{
    public class ActionResult
    {
        public ActionResult() { }

        public ActionResult(bool result)
        {
            this.Result = result;
        }

        public ActionResult(bool result, Exception? exception) : this(result)
        {
            this.Exception = exception;
        }

        public bool Result { get; set; }
        public Exception? Exception { get; set; }
    }
}
