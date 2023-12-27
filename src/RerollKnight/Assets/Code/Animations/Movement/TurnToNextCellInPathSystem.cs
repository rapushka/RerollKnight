using Code.Component;
using Entitas;
using Entitas.Generic;
using UnityEngine;
using static Entitas.Generic.ScopeMatcher<Code.GameScope>;

namespace Code
{
    public class TurnToNextCellInPathSystem : IExecuteSystem
    {
        private readonly Contexts _contexts;
        private readonly IGroup<Entity<GameScope>> _movers;

        public TurnToNextCellInPathSystem(Contexts contexts)
        {
            _contexts = contexts;

            _movers = contexts.GetGroup(AllOf(Get<DestinationPosition>()));
        }

        private Entity<GameScope> CurrentActor => _contexts.Get<GameScope>().Unique.GetEntity<CurrentActor>();

        public void Execute()
        {
            foreach (var e in _movers.GetEntities())
            {
                var moverCoordinates = e.Get<Position>().Value;
                var targetCoordinates = e.Get<DestinationPosition>().Value;

                var direction = targetCoordinates - moverCoordinates;

                var rotationAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg;
                var rotation = Quaternion.Euler(0f, rotationAngle, 0f);

                CurrentActor.Replace<Rotation, Quaternion>(rotation);
            }
        }

    }
}