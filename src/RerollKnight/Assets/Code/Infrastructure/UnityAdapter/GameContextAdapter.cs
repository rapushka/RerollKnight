using UnityEngine;

namespace Code
{
	public class GameContextAdapter : EntitasAdapterBase
	{
		[SerializeField] private EntityBehaviourBase[] _entityBehaviours;

		protected override Feature GetFeature() => new GameFeature(Contexts, _entityBehaviours);
	}
}