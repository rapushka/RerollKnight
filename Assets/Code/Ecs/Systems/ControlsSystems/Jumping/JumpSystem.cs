using System.Collections.Generic;
using Entitas;
using UnityEngine;

namespace Code.Ecs.Systems.ControlsSystems.Jumping
{
	public sealed class JumpSystem : ReactiveSystem<GameEntity>
	{
		public JumpSystem(Contexts contexts)
			: base(contexts.game) { }

		protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
			=> context.CreateCollector(GameMatcher.Jump);

		protected override bool Filter(GameEntity entity) => entity.hasRigidbody;

		protected override void Execute(List<GameEntity> entites)
		{
			foreach (GameEntity e in entites)
			{
				e.rigidbody.Value.AddForce(Vector3.up * 20, ForceMode.Impulse);
			}
		}
	}
}