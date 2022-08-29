using Code.Workflow.Extensions;
using Entitas;
using UnityEngine;

namespace Code.Unity.Views
{
	public class SpawnPositionListener : MonoBehaviour, ISpawnPositionListener, IEventListener
	{
		private GameEntity _entity;
		private CharacterController _characterController;

		private void Awake()
		{
			_characterController = GetComponent<CharacterController>();
		}

		public void OnSpawnPosition(GameEntity entity, Vector3 value)
		{
			SetActualPosition(value);

			entity.RemoveSpawnPosition();
			UnRegister();
		}

		private void SetActualPosition(Vector3 position)
		{
			_characterController.Do
			(
				@if: (c) => c != null,
				@do: (c) => c.WarpToLocal(position),
				elseDo: (_) => transform.localPosition = position
			);
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