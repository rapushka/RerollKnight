using UnityEngine;

namespace Code
{
	public interface IHoldersProvider
	{
		Transform     ChipsHolder { get; }
		Transform     CellsHolder { get; }
		RectTransform HudHolder   { get; }
	}

	public class HoldersProvider : MonoBehaviour, IHoldersProvider
	{
		[field: SerializeField] public Transform     ChipsHolder { get; private set; }
		[field: SerializeField] public Transform     CellsHolder { get; private set; }
		[field: SerializeField] public RectTransform HudHolder   { get; private set; }
	}
}