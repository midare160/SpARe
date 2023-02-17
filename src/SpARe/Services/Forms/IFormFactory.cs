using SpARe.Services.Forms;

namespace SpARe.Services
{
    public interface IFormFactory
    {
        T GetForm<T>() where T : IForm;
        IForm GetForm(Type formType);
    }
}
