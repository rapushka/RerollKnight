using System.Linq;
using Code.Workflow.Extensions;
using Entitas;
using UnityEngine;

namespace Code.Ecs.Systems.GameLogic
{
	public sealed class LookAtSystem : IExecuteSystem
	{
		private readonly GameContext _gameContext;
		private readonly IGroup<GameEntity> _objects;

		public LookAtSystem(Contexts contexts)
		{
			_gameContext = contexts.game;

			_objects = contexts.game.GetAllOf(GameMatcher.LookAtObjectId, GameMatcher.Position);
		}

		public void Execute() 
			=> _objects.ForEach(TurnSubjectsTo);

		private void TurnSubjectsTo(GameEntity @object)
		{
			_gameContext
				.GetEntitiesWithLookAtSubjectId(@object.lookAtObjectId)
				.Where((s) => s.hasTransform)
				.ForEach((s) => TurnSubjectToObject(s, @object));
		}

		private static void TurnSubjectToObject(GameEntity entitySubject, GameEntity entityObject)
		{
			Transform subject = entitySubject.transform;
			Vector3 @object = entityObject.position.Value;
			
			subject.LookAt(@object);
		}
	}
}