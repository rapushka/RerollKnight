using Code.Component;
using Entitas.Generic;
using UnityEngine;
using Zenject;

namespace Code
{
	/// <summary> Now it's more like dump of different stuff </summary>
	public class Game
	{
		private readonly Contexts _contexts;

		[Inject]
		public Game(Contexts contexts)
		{
			_contexts = contexts;
		}

		public bool IsPlayerCurrentActor => CurrentActor?.Is<Player>() ?? false;

		private Entity<GameScope> CurrentActor => _contexts.Get<GameScope>().Unique.GetEntityOrDefault<CurrentActor>();

		public void EndTurn() => _contexts.Get<RequestScope>().CreateEntity().Add<EndTurn>();

		public void Exit()
		{
#if UNITY_EDITOR
			if (UnityEditor.EditorApplication.isPlaying)
				UnityEditor.EditorApplication.ExitPlaymode();
#endif

			Application.Quit();
		}
	}
}