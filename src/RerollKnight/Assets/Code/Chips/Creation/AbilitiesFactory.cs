using System.Collections.Generic;
using Code.Component;
using Entitas.Generic;
using Zenject;

namespace Code
{
	public class AbilitiesFactory
	{
		private readonly Contexts _contexts;

		[Inject]
		public AbilitiesFactory(Contexts contexts)
		{
			_contexts = contexts;
		}

		public void Create(Entity<GameScope> chip, AbilityConfig config)
		{
			Spawn(@for: chip)
				.Is<Teleport>(config.Kind.Is<Teleport>())
				.Is<SwitchPositions>(config.Kind.Is<SwitchPositions>())
				.Add<MaxCountOfTargets, int>(config.TargetsCount)
				.Add<TargetConstraints, List<ComponentConstraint>>(config.TargetConstraints)
				.Add<Range, int>(config.Range, @if: config.Range > -1)
				;
		}

		private Entity<ChipsScope> Spawn(Entity<GameScope> @for)
			=> _contexts.Get<ChipsScope>().CreateEntity()
			            .Add<Component.AbilityState, AbilityState>(AbilityState.Inactive)
			            .Add<AbilityOfChip, int>(@for.Get<ID>().Value);
	}
}