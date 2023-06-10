using UnityEngine;

namespace Code
{
	public class GameContextAdapter : EntitasAdapterBase
	{
		[SerializeField] private EntityBehaviourBase[] _entityBehaviours;

		protected override Feature Feature => new GameFeature(Contexts, _entityBehaviours);
	}
}