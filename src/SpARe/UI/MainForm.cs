using MediatR;
using SpARe.Extensions;
using SpARe.Requests;

namespace SpARe;

public partial class MainForm : Form
{
    private readonly IMediator _mediator;

    public MainForm(IMediator mediator)
    {
        _mediator = mediator;

        InitializeComponent();
    }

    private async void InstallButton_Click(object sender, EventArgs e)
    {
        using var _ = this.StartWaitCursor();
        await _mediator.Send<InstallRequest>();
    }

    private async void StartButton_Click(object sender, EventArgs e)
    {
        using var _ = this.StartWaitCursor();
        await _mediator.Send<StartAdRemovalRequest>();
    }

    private async void RevertButton_Click(object sender, EventArgs e)
    {
        using var _ = this.StartWaitCursor();
        await _mediator.Send<RevertAdRemovalRequest>();
    }

    private async void AboutButton_Click(object sender, EventArgs e)
    {
        using var _ = this.StartWaitCursor();
        await _mediator.Send(new AboutRequest(this));
    }
}
