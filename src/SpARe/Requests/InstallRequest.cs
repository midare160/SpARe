namespace SpARe.Requests
{
    public class InstallRequest : IParameterlessRequest<InstallRequest>
    {
        public static InstallRequest Instance { get; } = new();
    }
}
