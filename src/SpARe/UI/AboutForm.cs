using Microsoft.Extensions.Hosting;
using System.Reflection;

namespace SpARe.UI
{
    partial class AboutForm : Form
    {
        private static T? GetAssemblyAttribute<T>() where T : Attribute =>
            Assembly.GetExecutingAssembly().GetCustomAttribute<T>();

        public AboutForm() => InitializeComponent();

        private void AboutForm_Load(object sender, EventArgs e)
        {
            this.Text = $"About {GetAssemblyAttribute<AssemblyTitleAttribute>()?.Title}";
            this.ProductNameLabel.Text = GetAssemblyAttribute<AssemblyProductAttribute>()?.Product;
            this.VersionLabel.Text = $"v. {GetAssemblyAttribute<AssemblyVersionAttribute>()?.Version}";
            this.CopyrightLabel.Text = GetAssemblyAttribute<AssemblyCopyrightAttribute>()?.Copyright;
            this.CompanyNameLabel.Text = GetAssemblyAttribute<AssemblyCompanyAttribute>()?.Company;
            this.DescriptionTextBox.Text = GetAssemblyAttribute<AssemblyDescriptionAttribute>()?.Description;
        }
    }
}
