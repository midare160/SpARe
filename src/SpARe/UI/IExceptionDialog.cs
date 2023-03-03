namespace SpARe.UI;

public interface IExceptionDialog
{
    TaskDialogButton? ShowNew(Exception exception);
}
