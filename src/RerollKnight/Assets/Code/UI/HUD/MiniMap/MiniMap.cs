using System.Collections;
using Code.Component;
using Entitas;
using Entitas.Generic;
using UnityEngine;
using Zenject;
using static Entitas.Generic.ScopeMatcher<Code.GameScope>;

namespace Code
{
	public class MiniMap : MonoBehaviour, IInitializable
	{
		[SerializeField] private RoomPreview _roomPreviewPrefab;
		[SerializeField] private RectTransform _root;

		private GameplayStateMachine _stateMachine;
		private Contexts _contexts;
		private MapProvider _mapProvider;
		private IGroup<Entity<GameScope>> _rooms;

		[Inject]
		public void Construct(GameplayStateMachine stateMachine, Contexts contexts, MapProvider mapProvider)
		{
			_contexts = contexts;
			_stateMachine = stateMachine;
			_mapProvider = mapProvider;

			_rooms = _contexts.GetGroup(Get<Room>());
		}

		public void Initialize()
		{
			StartCoroutine(LoadMap());
		}

		public IEnumerator LoadMap()
		{
			yield return new WaitUntil(WaitForLevelLoading);

			foreach (var room in _rooms)
			{
				var roomPreview = Instantiate(_roomPreviewPrefab, _root);
				roomPreview.SetData(_mapProvider, room);
			}
		}

		private bool WaitForLevelLoading() => _stateMachine.NullableCurrentState is ObservingGameplayState;
	}
}