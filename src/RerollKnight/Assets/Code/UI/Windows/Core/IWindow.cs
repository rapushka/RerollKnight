namespace Code
{
	public interface IWindow
	{
		bool IsOpen { get; }
		void Show();
		void Hide();
	}

	/// <summary> Can't be closed by opening other window </summary>
	public interface IUninterruptedWindow { }
}