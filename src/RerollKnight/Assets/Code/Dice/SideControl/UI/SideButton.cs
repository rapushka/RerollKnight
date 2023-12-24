using System;

namespace Code
{
	public class SideButton : ButtonBase
	{
		public new event Action<int> Clicked;

		public int SideNumber { get; private set; }

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
			SideNumber = sideNumber;
			Text = SideNumber.ToString();
		}

		private void InvokeClicked() => Clicked?.Invoke(SideNumber);
	}
}