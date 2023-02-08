namespace SpARe.Services
{
    public interface IAdRemoverService
    {
        Task StartAsync();
        Task RevertAsync();
    }
}
