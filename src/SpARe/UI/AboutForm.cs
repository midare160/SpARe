using SpARe.Services.Forms;
using System.Reflection;

namespace SpARe.UI
{
    partial class AboutForm : Form, ITransientForm
    {
        public AboutForm() => InitializeComponent();

        private void AboutForm_Load(object sender, EventArgs e)
        {
            var assembly = Assembly.GetExecutingAssembly();

            this.Text = $"About {assembly.GetCustomAttribute<AssemblyTitleAttribute>()?.Title}";
            this.ProductNameLabel.Text = assembly.GetCustomAttribute<AssemblyProductAttribute>()?.Product;
            this.VersionLabel.Text = $"v. {Assembly.GetExecutingAssembly().GetName().Version}";
            this.CopyrightLabel.Text = assembly.GetCustomAttribute<AssemblyCopyrightAttribute>()?.Copyright;
        }

        private void AboutForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                Close();
            }
        }
    }
}
