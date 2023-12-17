using System.Collections;
using System.Collections.Generic;
using Code.Component;
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

		[Inject]
		public void Construct(GameplayStateMachine stateMachine, Contexts contexts, MapProvider mapProvider)
		{
			_contexts = contexts;
			_stateMachine = stateMachine;
			_mapProvider = mapProvider;
		}

		public void Initialize()
		{
			StartCoroutine(LoadMap());
		}

		private IEnumerable<Entity<GameScope>> Rooms
			=> _contexts.Get<GameScope>().GetGroup(Get<Room>()).GetEntities();

		public IEnumerator LoadMap()
		{
			yield return new WaitUntil(WaitForLevelLoading);

			//
			foreach (var room in Rooms)
			{
				Debug.Log($"room.coordinates = {room.GetCoordinates()}");
				var roomPreview = Instantiate(_roomPreviewPrefab, _root);
				roomPreview.SetData(_mapProvider, room);
			}
		}

		private bool WaitForLevelLoading()
		{
			return _stateMachine.CurrentState is ObservingGameplayState;
		}
	}
}