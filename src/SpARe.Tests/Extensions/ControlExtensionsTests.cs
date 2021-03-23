using Spare.Extensions;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Windows.Forms;
using Xunit;

namespace Spare.Tests.Extensions
{
    public class ControlExtensionsTests
    {
        [Fact]
        public async Task RunAsync_DisabledControl_ControlStaysDisabled()
        {
            using var control = new Control("TestControl")
            {
                Enabled = false
            };

            await control.RunAsync(() => Debug.WriteLine("Testline"), control);

            Assert.False(control.Enabled);
        }
    }
}
