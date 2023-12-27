using System.Linq;
using Code.Component;
using Entitas;
using Entitas.Generic;
using UnityEngine;
using static Entitas.Generic.ScopeMatcher<Code.GameScope>;

namespace Code
{
	public class MoveToNextCellInPathSystem : IExecuteSystem, ITearDownSystem
	{
		private readonly IViewConfig _viewConfig;
		private readonly IGroup<Entity<GameScope>> _notDirectedEntities;

		public MoveToNextCellInPathSystem(Contexts contexts, IViewConfig viewConfig)
		{
			_viewConfig = viewConfig;
			_notDirectedEntities = contexts.GetGroup(AllOf(Get<Path>()).NoneOf(Get<DestinationPosition>()));
		}
		
		public void Execute()
		{
			foreach (var e in _notDirectedEntities.GetEntities())
			{
				var path = e.Get<Path>().Value;
				var nextCoordinates = path.Dequeue();

				Debug.Log($"nextCoordinates = {nextCoordinates} WorldPoint = {nextCoordinates.ToWorldPoint()}");
				e.Add<DestinationPosition, Vector3>(nextCoordinates.ToWorldPoint());
				e.Replace<MovingSpeed, float>(_viewConfig.DiceWalkingSpeed);

				if (!path.Any())
					e.Remove<Path>();
			}
		}

		public void TearDown()
		{
		}
	}
}