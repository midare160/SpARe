using SpARe.Services.Forms;
using System.Reflection;

namespace SpARe.UI
{
    partial class AboutForm : Form, ITransientForm
    {
        private static readonly Assembly CurrentAssembly = Assembly.GetExecutingAssembly();

        public AboutForm() => InitializeComponent();

        private void AboutForm_Load(object sender, EventArgs e)
        {
            Text = $"About {CurrentAssembly.GetCustomAttribute<AssemblyTitleAttribute>()!.Title}";
            VersionLabel.Text = $"v. {CurrentAssembly.GetCustomAttribute<AssemblyFileVersionAttribute>()!.Version}";
            CopyrightLabel.Text = CurrentAssembly.GetCustomAttribute<AssemblyCopyrightAttribute>()!.Copyright;

            var assemblyProduct = CurrentAssembly.GetCustomAttribute<AssemblyProductAttribute>();
            var assemblyConfiguration = CurrentAssembly.GetCustomAttribute<AssemblyConfigurationAttribute>();
            ProductNameLabel.Text = $"{assemblyProduct!.Product} ({assemblyConfiguration!.Configuration})";
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
