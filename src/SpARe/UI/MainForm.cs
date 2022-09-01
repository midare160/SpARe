using SpARe.Aspects;
using SpARe.Services;
using SpARe.Services.Forms;
using SpARe.Services.General;
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

        [WaitCursor]
        private async void StartButton_Click(object sender, EventArgs e) =>
            await _adRemoverService.StartAsync();

        [WaitCursor]
        private async void RevertButton_Click(object sender, EventArgs e) => 
            await _adRemoverService.RevertAsync();

        [WaitCursor]
        private void AboutButton_Click(object sender, EventArgs e)
        {
            using var aboutForm = _formFactory.GetForm<AboutForm>();
            aboutForm.ShowDialog(this);
        }
    }
}
