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

		public Entity<ChipsScope> Create(AbilityConfigBehaviour config, Entity<GameScope> chip)
		{
			return config.AddAll(Spawn(@for: chip));

			// Spawn(@for: chip)
			// 	.Is<Teleport>(config.Kind.Is<Teleport>())
			// 	.Is<SwitchPositions>(config.Kind.Is<SwitchPositions>())
			// 	.Is<Kick>(config.Kind.Is<Kick>())
			// 	.Add<MaxCountOfTargets, int>(config.TargetsCount)
			// 	.Add<TargetConstraints, List<ComponentConstraint>>(config.TargetConstraints)
			// 	.Add<Range, int>(config.Range, @if: config.Range > -1)
			// 	;
		}

		private Entity<ChipsScope> Spawn(Entity<GameScope> @for)
			=> _contexts.Get<ChipsScope>().CreateEntity()
			            .Add<Component.AbilityState, AbilityState>(AbilityState.Inactive)
			            .Add<ForeignID, string>(@for.Get<ID>().Value);
	}
}