using UnityEngine;

namespace Code
{
	public class GameContextAdapter : EntitasAdapterBase
	{
		[SerializeField] private GameEntityBehaviour[] _entityBehaviours;

		protected override Feature GetFeature() => new GameFeature(Contexts, _entityBehaviours);
	}
}