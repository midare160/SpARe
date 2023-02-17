using System.ComponentModel;

namespace SpARe.Services.Forms
{
	public interface IForm : IContainerControl, IComponent, IWin32Window, ISynchronizeInvoke
	{
		void Show();
		void Show(IWin32Window? owner);
		DialogResult ShowDialog(IWin32Window? owner);
		DialogResult ShowDialog();
		void Close();
	}

	public interface ISingletonForm : IForm { }

	public interface ITransientForm : IForm { }
}
