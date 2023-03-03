using MediatR;
using SpARe.Requests;
using SpARe.UI;
using WindowsFormsLifetime;

namespace SpARe.Handlers;

public class AboutHandler : IRequestHandler<AboutRequest>
{
    private readonly IFormProvider _formProvider;

    public AboutHandler(IFormProvider formProvider)
    {
        _formProvider = formProvider;
    }

    public async Task Handle(AboutRequest request, CancellationToken cancellationToken)
    {
        using var aboutForm = await _formProvider.GetFormAsync<AboutForm>();
        aboutForm.ShowDialog(request.Owner);
    }
}
