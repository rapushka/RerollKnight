using System;

namespace Code
{
	public class SideButton : ButtonBase
	{
		public new event Action<int> Clicked;

		private int _sideNumber;

		protected override void OnEnable()
		{
			base.OnEnable();
			base.Clicked += InvokeClicked;
		}

		protected override void OnDisable()
		{
			base.OnDisable();
			base.Clicked -= InvokeClicked;
		}

		public void SetData(int sideNumber)
		{
			_sideNumber = sideNumber;
			Text = _sideNumber.ToString();
		}

		private void InvokeClicked() => Clicked?.Invoke(_sideNumber);
	}
}