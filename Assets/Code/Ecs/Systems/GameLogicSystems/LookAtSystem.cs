using System.Linq;
using Code.Workflow.Extensions;
using Entitas;
using UnityEngine;

namespace Code.Ecs.Systems.GameLogicSystems
{
	public sealed class LookAtSystem : IExecuteSystem
	{
		private readonly GameContext _gameContext;
		private readonly IGroup<GameEntity> _objects;

		public LookAtSystem(Contexts contexts)
		{
			_gameContext = contexts.game;

			contexts.game.GetAllOf(GameMatcher.LookAtSubjectId, GameMatcher.Transform);
			_objects = contexts.game.GetAllOf(GameMatcher.LookAtObjectId, GameMatcher.Transform);
		}

		public void Execute()
		{
			_objects.GetEntities()
			        .ForEach(TurnSubjectsTo);
		}

		private void TurnSubjectsTo(GameEntity @object)
		{
			_gameContext
				.GetEntitiesWithLookAtSubjectId(@object.lookAtObjectId.Value)
				.Where((s) => s.hasTransform)
				.ForEach((s) => TurnSubjectToObject(s, @object));
		}

		private static void TurnSubjectToObject(GameEntity entitySubject, GameEntity entityObject)
		{
			Transform transformObject = entityObject.transform.Value;
			Transform transformSubject = entitySubject.transform.Value;

			transformObject.LookAt(transformSubject.position);
		}
	}
}