using UnityEngine;

namespace Code
{
	public class ResolutionSelector : Selector<Vector2Int>
	{
		protected override string Show(Vector2Int resolution)
			=> $"{resolution.x}x{resolution.y}";
	}
}