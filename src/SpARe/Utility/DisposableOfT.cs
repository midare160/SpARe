namespace SpARe.Utility
{
    public class Disposable<T> : IDisposable
    {
        private readonly T? _argument;
        private readonly Action<T?> _disposeAction;

        public Disposable(T? argument, Action<T?> disposeAction)
        {
            _argument = argument;
            _disposeAction = disposeAction;
        }

        public void Dispose()
        {
            _disposeAction(_argument);
            GC.SuppressFinalize(this);
        }
    }
}
