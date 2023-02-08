namespace SpARe.Utility
{
    public class Disposable : IDisposable
    {
        private readonly Action _disposeAction;

        public Disposable(Action disposeAction)
        {
            ArgumentNullException.ThrowIfNull(disposeAction);

            _disposeAction = disposeAction;
        }

        public void Dispose() => _disposeAction();
    }
}
