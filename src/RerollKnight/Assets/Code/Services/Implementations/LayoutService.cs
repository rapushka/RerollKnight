using UnityEngine;

namespace Code
{
	public interface ILayoutService
	{
		Vector3 AboveFieldOffset  { get; }
		Vector3 PickingChipOffset { get; }
	}

	[CreateAssetMenu(fileName = "Layout", menuName = "Layout", order = 0)]
	public class LayoutService : ScriptableObject, ILayoutService
	{
		[field: SerializeField] public Vector3 AboveFieldOffset  { get; private set; }
		[field: SerializeField] public Vector3 PickingChipOffset { get; private set; }
	}
}