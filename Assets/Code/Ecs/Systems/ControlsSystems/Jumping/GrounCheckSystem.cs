using System.Collections.Generic;
using Entitas;
using UnityEngine;

namespace Code.Ecs.Systems.ControlsSystems.Jumping
{

	public sealed class GroundCheckSystem : ReactiveSystem<InputEntity>
	{
		public GroundCheckSystem(Contexts contexts)
			: base(contexts.input) { }

		protected override ICollector<InputEntity> GetTrigger(IContext<InputEntity> context)
			=> context.CreateCollector(InputMatcher.Jumping.Added());

		protected override bool Filter(InputEntity entity) => true;

		protected override void Execute(List<InputEntity> entites)
		{
			foreach (InputEntity e in entites)
			{
				Debug.Log("JumpingAdded");
			}
		}
	}
}