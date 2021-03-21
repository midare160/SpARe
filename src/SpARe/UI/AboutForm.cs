using System;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;

namespace Spare.UI
{
    partial class AboutForm : Form
    {
        #region Static
        private static readonly Assembly ExecutingAssembly = Assembly.GetExecutingAssembly();

        private static T? GetAttribute<T>() where T : Attribute =>
            (T?)ExecutingAssembly.GetCustomAttributes(typeof(T), false).FirstOrDefault();
        #endregion

        #region Constructors
        public AboutForm()
        {
            InitializeComponent();

            this.Text = $"About {AssemblyTitle}";
            this.ProductNameLabel.Text = AssemblyProduct;
            this.VersionLabel.Text = $"v. {AssemblyVersion}";
            this.CopyrightLabel.Text = AssemblyCopyright;
            this.CompanyNameLabel.Text = AssemblyCompany;
            this.DescriptionLabel.Text = AssemblyDescription;
        }
        #endregion

        #region Properties
        public static string? AssemblyTitle
        {
            get
            {
                var attribute = GetAttribute<AssemblyTitleAttribute>()?.Title;

                if (string.IsNullOrEmpty(attribute))
                {
                    return Path.GetFileNameWithoutExtension(Assembly.GetExecutingAssembly().Location);
                }

                return attribute;
            }
        }

        public static string? AssemblyVersion => ExecutingAssembly.GetName().Version?.ToString();

        public static string? AssemblyDescription => GetAttribute<AssemblyDescriptionAttribute>()?.Description;

        public static string? AssemblyProduct => GetAttribute<AssemblyProductAttribute>()?.Product;

        public static string? AssemblyCopyright => GetAttribute<AssemblyCopyrightAttribute>()?.Copyright;

        public static string? AssemblyCompany => GetAttribute<AssemblyCompanyAttribute>()?.Company;
        #endregion

        #region Events
        private void OkButton_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            this.Close();
        }
        #endregion
    }
}
