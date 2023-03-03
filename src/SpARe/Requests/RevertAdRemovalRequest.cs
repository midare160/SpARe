namespace SpARe.Requests
{
    public class RevertAdRemovalRequest : IParameterlessRequest<RevertAdRemovalRequest>
    {
        public static RevertAdRemovalRequest Instance { get; } = new();
    }
}
