using Entitas;
using UnityEngine;

namespace Code
{
	public interface IEntitiesManipulatorService
	{
		void UnpickAll(bool immediately = false)
		{
			UnpickChip(immediately);
			UnpickTargets(immediately);
		}

		void UnpickChip(bool immediately = false);

		void UnpickTargets(bool immediately = false);
	}

	public class EntitiesManipulatorService : IEntitiesManipulatorService
	{
		private readonly IGroup<GameEntity> _targets;
		private readonly Contexts _contexts;

		public EntitiesManipulatorService(Contexts contexts)
		{
			_contexts = contexts;
			_targets = _contexts.game.GetGroup(GameMatcher.PickedTarget);
		}

		public void UnpickChip(bool immediately = false)
		{
			_contexts.game.pickedChipEntity?.Unpick();

			if (!immediately)
				Debug.LogWarning("Chip was unpicked immediately, cuz there's no request for it");
		}

		public void UnpickTargets(bool immediately = false)
		{
			if (!immediately)
			{
				RequestEmitter.Instance.Send<UnpickTargetsRequest>();
				return;
			}

			foreach (var e in _targets.GetEntities())
				e.Unpick();
		}
	}
}