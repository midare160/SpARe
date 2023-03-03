namespace SpARe.Requests
{
    public class StartAdRemovalRequest : IParameterlessRequest<StartAdRemovalRequest>
    {
        public static StartAdRemovalRequest Instance { get; } = new();
    }
}
