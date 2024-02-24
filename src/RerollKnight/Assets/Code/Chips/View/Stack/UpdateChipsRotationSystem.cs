using Code.Component;
using Entitas;
using Entitas.Generic;
using UnityEngine;
using Zenject;
using static Entitas.Generic.ScopeMatcher<Code.GameScope>;
using RotationListener = Entitas.Generic.ListenerComponent<Code.GameScope, Code.Component.Rotation>;

namespace Code
{
	public sealed class UpdateChipsRotationSystem : IExecuteSystem
	{
		private readonly IViewConfig _viewConfig;
		private readonly IGroup<Entity<GameScope>> _chips;

		[Inject]
		public UpdateChipsRotationSystem(Contexts contexts, IViewConfig viewConfig)
		{
			_viewConfig = viewConfig;
			_chips = contexts.GetGroup(AllOf(Get<Rotation>(), Get<Chip>(), Get<RotationListener>()));
		}

		public void Execute()
		{
			foreach (var e in _chips)
			{
				var desiredRotationX = e.IsFocused()
					? _viewConfig.Chips.PickedRotationX
					: _viewConfig.Chips.DefaultRotationX;

				var rotation = e.Get<Rotation>().Value;

				if (!desiredRotationX.ApproximatelyEquals(rotation.eulerAngles.x))
					e.Replace<DestinationRotation, Quaternion>(rotation.SetEuler(x: desiredRotationX));
			}
		}
	}
}