using System.Collections.Generic;
using System.Linq;
using Code.Component;
using Entitas;
using Entitas.Generic;
using JetBrains.Annotations;
using UnityEngine;
using static Code.Coordinates.Layer;
using static Entitas.Generic.ScopeMatcher<Code.GameScope>;

namespace Code
{
	public class TestPathfindingSystem : IExecuteSystem
	{
		private readonly Contexts _contexts;
		private readonly VisionService _visionService;
		private readonly IGroup<Entity<GameScope>> _clicked;

		public TestPathfindingSystem(Contexts contexts, VisionService visionService)
		{
			_contexts = contexts;
			_visionService = visionService;

			_clicked = contexts.GetGroup(AllOf(Get<Component.Coordinates>(), Get<Clicked>()));
		}

		private Entity<GameScope> CurrentActor => _contexts.Get<GameScope>().Unique.GetEntity<CurrentActor>();

		public void Execute()
		{
			foreach (var target in _clicked)
			{
				var actorCoordinates = CurrentActor.GetCoordinates().WithLayer(Default);
				var targetCoordinates = target.GetCoordinates().WithLayer(Default);
				// var path = _pathfinding.FindPath(actorCoordinates, targetCoordinates);

				var isStraightLinePath = _visionService.IsVisible(actorCoordinates, targetCoordinates);
				Debug.Log($"isStraightLinePath = {isStraightLinePath}");
			}
		}

		[UsedImplicitly]
		private static void PrintPath(List<Coordinates> path)
		{
			if (path.Any())
			{
				Debug.Log("found path:");
				foreach (var coordinates in path)
					Debug.Log(coordinates);

				Debug.Log("---");
			}
			else
			{
				Debug.Log("path not found:(");
			}
		}
	}
}