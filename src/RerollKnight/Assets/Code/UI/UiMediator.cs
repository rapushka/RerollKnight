using Code.Component;
using Entitas.Generic;
using JetBrains.Annotations;
using UnityEngine;
using Zenject;

namespace Code
{
	public class UiMediator
	{
		private Contexts _contexts;
		private ISceneTransfer _sceneTransfer;

		[Inject]
		public void Construct(Contexts contexts, ISceneTransfer sceneTransfer)
		{
			_contexts = contexts;
			_sceneTransfer = sceneTransfer;
		}

		[CanBeNull]
		private Entity<GameScope> CurrentActor => _contexts.Get<GameScope>().Unique.GetEntityOrDefault<CurrentActor>();

		public void EndTurn() => _contexts.Get<RequestScope>().CreateEntity().Add<EndTurn>();

		public bool IsEndTurnButtonAvailable => CurrentActor?.Is<Player>() ?? false;

		public void OpenGameplay() => _sceneTransfer.ToGameplay();

		public void OpenSettings() { }

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