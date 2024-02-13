using Code.Component;
using Entitas.Generic;
using Zenject;

namespace Code
{
	public interface IAbilitiesFactory
	{
		Entity<ChipsScope> Create(AbilityConfigBehaviour config, Entity<GameScope> chip);
	}

	public class AbilitiesFactory : IAbilitiesFactory
	{
		private readonly Contexts _contexts;

		[Inject]
		public AbilitiesFactory(Contexts contexts)
		{
			_contexts = contexts;
		}

		public Entity<ChipsScope> Create(AbilityConfigBehaviour config, Entity<GameScope> chip)
			=> config.AddAll(Spawn(@for: chip));

		private Entity<ChipsScope> Spawn(Entity<GameScope> @for)
			=> _contexts.Get<ChipsScope>().CreateEntity()
			            .Add<Component.AbilityState, AbilityState>(AbilityState.Inactive)
			            .Add<ForeignID, string>(@for.Get<ID>().Value);
	}
}