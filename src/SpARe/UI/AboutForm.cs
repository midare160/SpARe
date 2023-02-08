using SpARe.Extensions;
using SpARe.Services.Forms;
using System.Reflection;

namespace SpARe.UI
{
    partial class AboutForm : Form, ITransientForm
    {
        private static readonly Assembly CurrentAssembly = typeof(IAssemblyMarker).Assembly;

        public AboutForm() => InitializeComponent();

        private void AboutForm_Load(object sender, EventArgs e)
        {
            using var _ = this.StartWaitCursor();

            Text = $"About {CurrentAssembly.GetCustomAttribute<AssemblyTitleAttribute>()!.Title}";
            VersionLabel.Text = $"v. {CurrentAssembly.GetCustomAttribute<AssemblyFileVersionAttribute>()!.Version}";
            CopyrightLabel.Text = CurrentAssembly.GetCustomAttribute<AssemblyCopyrightAttribute>()!.Copyright;

            var assemblyProduct = CurrentAssembly.GetCustomAttribute<AssemblyProductAttribute>();
            var assemblyConfiguration = CurrentAssembly.GetCustomAttribute<AssemblyConfigurationAttribute>();
            ProductNameLabel.Text = $"{assemblyProduct!.Product} ({assemblyConfiguration!.Configuration})";
        }
    }
}
