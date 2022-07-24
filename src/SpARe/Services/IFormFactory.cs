namespace SpARe.Services
{
    public interface IFormFactory
    {
        T GetForm<T>() where T : Form;
    }
}
