namespace SpARe.Requests;

public class AboutRequest : IParameterlessRequest<AboutRequest>
{
    public static AboutRequest Instance { get; } = new();

    public AboutRequest(IWin32Window? owner = null)
    {
        Owner = owner;
    }

    public IWin32Window? Owner { get; }
}
