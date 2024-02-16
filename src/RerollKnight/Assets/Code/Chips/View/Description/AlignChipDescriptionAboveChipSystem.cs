using Code.Component;
using Entitas;
using Entitas.Generic;
using Zenject;
using static Entitas.Generic.ScopeMatcher<Code.GameScope>;

namespace Code
{
	public sealed class AlignChipDescriptionAboveChipSystem : IExecuteSystem
	{
		private readonly ChipDescriptionWindow _window;
		private readonly IViewConfig _viewConfig;
		private readonly CamerasProvider _cameras;
		private readonly IHoldersProvider _holders;

		private readonly IGroup<Entity<GameScope>> _chips;

		[Inject]
		public AlignChipDescriptionAboveChipSystem
		(
			Contexts contexts,
			ChipDescriptionWindow window,
			IViewConfig viewConfig,
			CamerasProvider cameras,
			IHoldersProvider holders
		)
		{
			_window = window;
			_viewConfig = viewConfig;
			_cameras = cameras;
			_holders = holders;

			_chips = contexts.GetGroup(AllOf(Get<Chip>(), Get<Hovered>()));
		}

		public void Execute()
		{
			foreach (var e in _chips)
			{
				var localPosition = e.Get<Position>().Value;
				var worldPosition = _holders.ChipsHolder.TransformPoint(localPosition);
				var screenPoint = _cameras.UICamera.WorldToScreenPoint(worldPosition);
				_window.transform.position = screenPoint + _viewConfig.Chips.DescriptionOffset;
			}
		}
	}
}