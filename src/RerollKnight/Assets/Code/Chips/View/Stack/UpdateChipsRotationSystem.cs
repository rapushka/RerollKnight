using System.Collections.Generic;
using Code.Component;
using Entitas;
using Entitas.Generic;
using UnityEngine;
using Zenject;
using static Entitas.Generic.ScopeMatcher<Code.GameScope>;
using RotationListener = Entitas.Generic.ListenerComponent<Code.GameScope, Code.Component.Rotation>;

namespace Code
{
	public sealed class UpdateChipsRotationSystem : ReactiveSystem<Entity<GameScope>>
	{
		private readonly IViewConfig _viewConfig;

		[Inject]
		public UpdateChipsRotationSystem(Contexts contexts, IViewConfig viewConfig)
			: base(contexts.Get<GameScope>())
		{
			_viewConfig = viewConfig;
		}

		protected override ICollector<Entity<GameScope>> GetTrigger(IContext<Entity<GameScope>> context)
			=> context.CreateCollector(AllOf(Get<Rotation>(), Get<Chip>(), Get<RotationListener>()));

		protected override bool Filter(Entity<GameScope> entity) => true;

		protected override void Execute(List<Entity<GameScope>> entities)
		{
			foreach (var e in entities)
			{
				var desiredRotationX = e.Is<PickedChip>()
					? _viewConfig.Chips.PickedRotationX
					: _viewConfig.Chips.DefaultRotationX;

				var rotation = e.Get<Rotation>().Value;
				var eulerRotation = rotation.eulerAngles;

				if (!desiredRotationX.ApproximatelyEquals(eulerRotation.x))
				{
					// doesn't work
					e.Replace<Rotation, Quaternion>(rotation.SetEuler(x: desiredRotationX));
				}
			}
		}
	}
}