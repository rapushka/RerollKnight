using UnityEngine;

namespace Code
{
	public interface ILayoutService
	{
		Vector3 OverFieldOffset  { get; }
		Vector3 PickingChipOffset { get; }
	}

	[CreateAssetMenu(fileName = "Layout", menuName = "Layout", order = 0)]
	public class LayoutService : ScriptableObject, ILayoutService
	{
		[field: SerializeField] public Vector3 OverFieldOffset  { get; private set; }
		[field: SerializeField] public Vector3 PickingChipOffset { get; private set; }
	}
}