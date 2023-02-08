using SpARe.Extensions;
using SpARe.Services;
using SpARe.Services.Forms;
using SpARe.UI;

namespace SpARe
{
    public partial class MainForm : Form, ISingletonForm
    {
        private readonly IFormFactory _formFactory;
        private readonly IAdRemoverService _adRemoverService;

        public MainForm(IFormFactory formFactory, IAdRemoverService adRemoverService)
        {
            _formFactory = formFactory;
            _adRemoverService = adRemoverService;

            InitializeComponent();
        }

        private async void StartButton_Click(object sender, EventArgs e)
        {
            using var _ = this.StartWaitCursor();

            await _adRemoverService.StartAsync();
        }

        private async void RevertButton_Click(object sender, EventArgs e)
        {
            using var _ = this.StartWaitCursor();

            await _adRemoverService.RevertAsync();
        }

        private void AboutButton_Click(object sender, EventArgs e)
        {
            using var _ = this.StartWaitCursor();

            using var aboutForm = _formFactory.GetForm<AboutForm>();
            aboutForm.ShowDialog(this);
        }
    }
}
