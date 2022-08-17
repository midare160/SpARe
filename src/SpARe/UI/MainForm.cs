using SpARe.Services;
using SpARe.Services.Forms;
using SpARe.UI;

namespace SpARe
{
    public partial class MainForm : Form, ISingletonForm
    {
        private readonly IFormFactory _formFactory;

        public MainForm(IFormFactory formFactory)
        {
            _formFactory = formFactory;

            InitializeComponent();
        }

        private void AboutButton_Click(object sender, EventArgs e)
        {
            using var aboutForm = _formFactory.GetForm<AboutForm>();
            aboutForm.ShowDialog(this);
        }
    }
}
