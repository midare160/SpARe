using PostSharp.Aspects;
using PostSharp.Serialization;
using System.Collections.Concurrent;

namespace SpARe.Aspects
{
    [PSerializable]
    public class WaitCursor : OnMethodBoundaryAspect
    {
        private static readonly ConcurrentDictionary<Control, int> _waitingMethods = new();
        private static readonly object _entryLock = new();
        private static readonly object _exitLock = new();

        public override void OnEntry(MethodExecutionArgs args)
        {
            lock (_entryLock)
            {
                var control = (Control)args.Instance;

                control.UseWaitCursor = true;
                _waitingMethods.AddOrUpdate(control, 1, (_, count) => ++count);
            }
        }

        public override void OnExit(MethodExecutionArgs args)
        {
            lock (_exitLock)
            {
                var control = (Control)args.Instance;

                if (_waitingMethods[control] <= 1)
                {
                    control.UseWaitCursor = false;
                }

                if (--_waitingMethods[control] == 0)
                {
                    _waitingMethods.TryRemove(control, out _);
                }
            }
        }
    }
}
