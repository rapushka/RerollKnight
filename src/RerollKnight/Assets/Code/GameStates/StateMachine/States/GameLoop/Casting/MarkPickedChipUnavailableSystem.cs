using Code.Component;
using Entitas;
using Entitas.Generic;

namespace Code
{
	public sealed class MarkPickedChipUnavailableSystem : IInitializeSystem
	{
		private readonly Contexts _contexts;

		public MarkPickedChipUnavailableSystem(Contexts contexts)
			=> _contexts = contexts;

		private Entity<GameScope> PickedChip => _contexts.Get<GameScope>().Unique.GetEntity<PickedChip>();

		public void Initialize()
			=> PickedChip.Is<AvailableToPick>(false);
	}
}