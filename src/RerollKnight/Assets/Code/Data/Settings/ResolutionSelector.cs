using UnityEngine;

namespace Code
{
	public class ResolutionSelector : Selector<Resolution>
	{
		protected override string Show(Resolution option)
			=> $"{option.width}x{option.height}";
	}
}