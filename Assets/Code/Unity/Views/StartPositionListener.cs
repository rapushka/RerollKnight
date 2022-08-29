using Code.Workflow.Extensions;
using Entitas;
using UnityEngine;

namespace Code.Unity.Views
{
	public class StartPositionListener : MonoBehaviour, ISpawnPositionListener, IEventListener
	{
		private GameEntity _entity;
		private CharacterController _characterController;

		private void Awake()
		{
			_characterController = GetComponent<CharacterController>();
		}

		public void OnSpawnPosition(GameEntity entity, Vector3 value)
		{
			_characterController.WarpTo(value);

			entity.RemoveSpawnPosition();
			UnRegister();
		}
		
		public void Register(IEntity entity)
		{
			_entity = (GameEntity)entity;

			_entity.AddSpawnPositionListener(this);

			_entity.Do(MoveToSpawnPosition, @if: HasSpawnPosition);
			
			bool HasSpawnPosition(GameEntity e) => e.hasSpawnPosition;
			void MoveToSpawnPosition(GameEntity e) => OnSpawnPosition(e, e.spawnPosition);
		}

		public void UnRegister() 
			=> _entity.RemoveSpawnPositionListener(this);
	}
}