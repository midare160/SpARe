namespace SpARe.Services.General
{
    public interface IAdRemoverService
    {
        Task StartAsync();
        Task RevertAsync();
    }
}
