using UnityEngine;

namespace Code
{
	public class EntityBehaviourSpawner : GameEntityBehaviour
	{
		[SerializeField] private GameEntityBehaviour _prefab;

		public override void Initialize(Contexts contexts)
		{
			var entityBehaviour = Instantiate(_prefab, transform.position, Quaternion.identity);
			entityBehaviour.Initialize(contexts);
			
			Destroy(gameObject);
		}
	}
}