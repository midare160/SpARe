namespace SpARe.Utility
{
    public class Disposable : Disposable<Action>
    {
        public Disposable(Action disposeAction)
            : base(disposeAction, static a => a!())
        {
        }
    }
}
